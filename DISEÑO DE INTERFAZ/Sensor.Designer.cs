
namespace DISEÑO_DE_INTERFAZ
{
    partial class Sensor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_Nombre = new System.Windows.Forms.Label();
            this.lb_Apellido = new System.Windows.Forms.Label();
            this.lb_Matricula = new System.Windows.Forms.Label();
            this.lb_nivalhc = new System.Windows.Forms.Label();
            this.tb_Nombre = new System.Windows.Forms.TextBox();
            this.tb_Apellidos = new System.Windows.Forms.TextBox();
            this.tb_Matricula = new System.Windows.Forms.TextBox();
            this.lb_indicadorAL = new System.Windows.Forms.Label();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Nombre
            // 
            this.lb_Nombre.AutoSize = true;
            this.lb_Nombre.ForeColor = System.Drawing.Color.Transparent;
            this.lb_Nombre.Location = new System.Drawing.Point(35, 59);
            this.lb_Nombre.Name = "lb_Nombre";
            this.lb_Nombre.Size = new System.Drawing.Size(77, 20);
            this.lb_Nombre.TabIndex = 0;
            this.lb_Nombre.Text = "Nombres:";
            // 
            // lb_Apellido
            // 
            this.lb_Apellido.AutoSize = true;
            this.lb_Apellido.ForeColor = System.Drawing.Color.Transparent;
            this.lb_Apellido.Location = new System.Drawing.Point(35, 132);
            this.lb_Apellido.Name = "lb_Apellido";
            this.lb_Apellido.Size = new System.Drawing.Size(77, 20);
            this.lb_Apellido.TabIndex = 1;
            this.lb_Apellido.Text = "Apellidos:";
            // 
            // lb_Matricula
            // 
            this.lb_Matricula.AutoSize = true;
            this.lb_Matricula.ForeColor = System.Drawing.Color.Transparent;
            this.lb_Matricula.Location = new System.Drawing.Point(35, 214);
            this.lb_Matricula.Name = "lb_Matricula";
            this.lb_Matricula.Size = new System.Drawing.Size(77, 20);
            this.lb_Matricula.TabIndex = 2;
            this.lb_Matricula.Text = "Matricula:";
            // 
            // lb_nivalhc
            // 
            this.lb_nivalhc.AutoSize = true;
            this.lb_nivalhc.ForeColor = System.Drawing.Color.Transparent;
            this.lb_nivalhc.Location = new System.Drawing.Point(484, 110);
            this.lb_nivalhc.Name = "lb_nivalhc";
            this.lb_nivalhc.Size = new System.Drawing.Size(163, 20);
            this.lb_nivalhc.TabIndex = 3;
            this.lb_nivalhc.Text = "NIVEL DE ALCOHOL";
            // 
            // tb_Nombre
            // 
            this.tb_Nombre.Location = new System.Drawing.Point(39, 85);
            this.tb_Nombre.Name = "tb_Nombre";
            this.tb_Nombre.Size = new System.Drawing.Size(244, 26);
            this.tb_Nombre.TabIndex = 4;
            // 
            // tb_Apellidos
            // 
            this.tb_Apellidos.Location = new System.Drawing.Point(39, 158);
            this.tb_Apellidos.Name = "tb_Apellidos";
            this.tb_Apellidos.Size = new System.Drawing.Size(244, 26);
            this.tb_Apellidos.TabIndex = 5;
            // 
            // tb_Matricula
            // 
            this.tb_Matricula.Location = new System.Drawing.Point(39, 241);
            this.tb_Matricula.Name = "tb_Matricula";
            this.tb_Matricula.Size = new System.Drawing.Size(244, 26);
            this.tb_Matricula.TabIndex = 6;
            // 
            // lb_indicadorAL
            // 
            this.lb_indicadorAL.AutoSize = true;
            this.lb_indicadorAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_indicadorAL.ForeColor = System.Drawing.Color.Transparent;
            this.lb_indicadorAL.Location = new System.Drawing.Point(529, 159);
            this.lb_indicadorAL.Name = "lb_indicadorAL";
            this.lb_indicadorAL.Size = new System.Drawing.Size(62, 29);
            this.lb_indicadorAL.TabIndex = 7;
            this.lb_indicadorAL.Text = "0.00";
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.BackColor = System.Drawing.Color.Green;
            this.btn_SaveData.Location = new System.Drawing.Point(184, 328);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(122, 73);
            this.btn_SaveData.TabIndex = 8;
            this.btn_SaveData.Text = "Guardar Registro";
            this.btn_SaveData.UseVisualStyleBackColor = false;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Red;
            this.btn_Delete.Location = new System.Drawing.Point(12, 328);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(122, 73);
            this.btn_Delete.TabIndex = 9;
            this.btn_Delete.Text = "Limpiar Campos";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.Color.Transparent;
            this.statusLabel.Location = new System.Drawing.Point(530, 241);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(76, 20);
            this.statusLabel.TabIndex = 10;
            this.statusLabel.Text = "Sin datos";
            // 
            // Sensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_SaveData);
            this.Controls.Add(this.lb_indicadorAL);
            this.Controls.Add(this.tb_Matricula);
            this.Controls.Add(this.tb_Apellidos);
            this.Controls.Add(this.tb_Nombre);
            this.Controls.Add(this.lb_nivalhc);
            this.Controls.Add(this.lb_Matricula);
            this.Controls.Add(this.lb_Apellido);
            this.Controls.Add(this.lb_Nombre);
            this.Name = "Sensor";
            this.Text = "Sensor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Nombre;
        private System.Windows.Forms.Label lb_Apellido;
        private System.Windows.Forms.Label lb_Matricula;
        private System.Windows.Forms.Label lb_nivalhc;
        private System.Windows.Forms.TextBox tb_Nombre;
        private System.Windows.Forms.TextBox tb_Apellidos;
        private System.Windows.Forms.TextBox tb_Matricula;
        private System.Windows.Forms.Label lb_indicadorAL;
        private System.Windows.Forms.Button btn_SaveData;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label statusLabel;
    }
}