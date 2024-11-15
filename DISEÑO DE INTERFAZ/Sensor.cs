using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using MySql.Data.MySqlClient; //IMPORTACION DE LA LOBRERIA SQL DE MySql.dll


namespace DISEÑO_DE_INTERFAZ
{
    public partial class Sensor : Form
    {
        //DECALARANDO DB
        private const string SQL_DB_Connection = "Server=localhost; Port=3308;Database=alcoholimetrodb; Uid=root;Pwd=;";
        delegate void SetTextDelegate(string value);
        private SerialPort ArduinoPort;
        private float currentAlcoholLevel = 0;

        public Sensor()
        {
            InitializeComponent();
            ConfigurarPuertoSerial();
            ConfigurarInterfaz();
        }

        private void ConfigurarPuertoSerial()
        {
            ArduinoPort = new SerialPort
            {
                PortName = "COM3",
                BaudRate = 9600,
                DataBits = 8,
                ReadTimeout = 500,
                WriteTimeout = 500
            };

            try
            {
                ArduinoPort.Open();
                ArduinoPort.DataReceived += DataReceivedHandler;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el puerto: " + ex.Message);
            }
        }

        private void ConfigurarInterfaz()
        {
            // Configurar los controles visuales aquí si es necesario
            lb_indicadorAL.Text = "0.00 mg/L";
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = ArduinoPort.ReadLine();
                if (data.StartsWith("BAC:"))
                {
                    string[] parts = data.Split(':');
                    if (parts.Length >= 2)
                    {
                        string alcoholValue = parts[1].Trim();
                        if (float.TryParse(alcoholValue.Split(' ')[0], out float mgL))
                        {
                            currentAlcoholLevel = mgL;
                            EscribirTxt($"{mgL:F2} mg/L");

                            // Actualizar estado visual
                            UpdateEstado(mgL);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores de lectura del puerto serial
                Console.WriteLine($"Error en la lectura del puerto serial: {ex.Message}");
            }
        }

        private void UpdateEstado(float mgL)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateEstado(mgL)));
                return;
            }

            if (mgL > 2.5f)
            {
                // Actualizar interfaz para estado de ebriedad
                // Por ejemplo:
                statusLabel.Text = "Estado: Ebriedad";
                statusLabel.ForeColor = Color.Red;
            }
            else
            {
                // Actualizar interfaz para estado normal
                // Por ejemplo:
                statusLabel.Text = "Estado: Normal";
                statusLabel.ForeColor = Color.Green;
            }
        }

        private void EscribirTxt(string dato)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new SetTextDelegate(EscribirTxt), dato);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar la interfaz: {ex.Message}");
                }
            }
            else
            {
                lb_indicadorAL.Text = dato;
            }
        }

        private void InRegBD(string nombres, string apellidos, string matricula, decimal nivel_alcohol)
        {
            using (MySqlConnection connection = new MySqlConnection(SQL_DB_Connection))
            {
                try
                {
                    connection.Open();
                    string insertQuery = @"INSERT INTO registros(NOMBRE, APELLIDOS, MATRICULA, NIVEL_ALCOHOL) 
                                         VALUES(@Nombre, @Apellidos, @Matricula, @Nivel_alcohol)";

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombres);
                        command.Parameters.AddWithValue("@Apellidos", apellidos);
                        command.Parameters.AddWithValue("@Matricula", matricula);
                        command.Parameters.AddWithValue("@Nivel_alcohol", nivel_alcohol);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Registro guardado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Nombre.Text) ||
                string.IsNullOrWhiteSpace(tb_Apellidos.Text) ||
                string.IsNullOrWhiteSpace(tb_Matricula.Text))
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(lb_indicadorAL.Text.Split(' ')[0], out decimal nivelAlcohol))
            {
                InRegBD(tb_Nombre.Text.Trim(),
                       tb_Apellidos.Text.Trim(),
                       tb_Matricula.Text.Trim(),
                       nivelAlcohol);

                // Limpiar campos después de guardar
                tb_Nombre.Clear();
                tb_Apellidos.Clear();
                tb_Matricula.Clear();
            }
            else
            {
                MessageBox.Show("Error al leer el nivel de alcohol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            tb_Nombre.Clear();
            tb_Matricula.Clear();
            tb_Apellidos.Clear();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (ArduinoPort != null && ArduinoPort.IsOpen)
            {
                ArduinoPort.Close();
            }
        }
    }
}
