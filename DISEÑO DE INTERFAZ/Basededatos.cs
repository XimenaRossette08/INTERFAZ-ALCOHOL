using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DISEÑO_DE_INTERFAZ
{
    public partial class Basededatos : Form
    {
        private const string SQL_DB_Connection = "Server=localhost; Port=3308;Database=alcoholimetrodb; Uid=root;Pwd=;";

        public Basededatos()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            // Seleccionar el primer item del combo por defecto
            cmbFiltro.SelectedIndex = 0;

            // Asociar eventos a los botones
            btnBuscar.Click += btnBuscar_Click;
            btnActualizar.Click += btnActualizar_Click;

            // Configurar las columnas del DataGridView
            dgvRegistros.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "ID" },
                new DataGridViewTextBoxColumn { Name = "NOMBRE", HeaderText = "Nombre" },
                new DataGridViewTextBoxColumn { Name = "APELLIDOS", HeaderText = "Apellidos" },
                new DataGridViewTextBoxColumn { Name = "MATRICULA", HeaderText = "Matrícula" },
                new DataGridViewTextBoxColumn { Name = "NIVEL_ALCOHOL", HeaderText = "Nivel de Alcohol (mg/L)" }
            });
        }

        private void CargarDatos(string filtro = "", string valorBusqueda = "")
        {
            using (MySqlConnection connection = new MySqlConnection(SQL_DB_Connection))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM registros";

                    if (!string.IsNullOrWhiteSpace(filtro) && !string.IsNullOrWhiteSpace(valorBusqueda))
                    {
                        query += $" WHERE {filtro} LIKE @valorBusqueda";
                    }

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(valorBusqueda))
                        {
                            command.Parameters.AddWithValue("@valorBusqueda", $"%{valorBusqueda}%");
                        }

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            dgvRegistros.Rows.Clear();

                            while (reader.Read())
                            {
                                dgvRegistros.Rows.Add(
                                    reader["ID"],
                                    reader["NOMBRE"],
                                    reader["APELLIDOS"],
                                    reader["MATRICULA"],
                                    reader["NIVEL_ALCOHOL"]
                                );
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = cmbFiltro.SelectedItem.ToString().ToUpper();
            string valorBusqueda = txtBusqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(valorBusqueda))
            {
                CargarDatos();
            }
            else
            {
                CargarDatos(columnaFiltro, valorBusqueda);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            CargarDatos();
        }
    }
}
