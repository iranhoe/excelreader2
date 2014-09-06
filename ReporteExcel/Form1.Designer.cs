namespace ReporteExcel
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listTraseras = new System.Windows.Forms.ListBox();
            this.listFrontales = new System.Windows.Forms.ListBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.lblFront = new System.Windows.Forms.Label();
            this.lblTras = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listTraseras
            // 
            this.listTraseras.FormattingEnabled = true;
            this.listTraseras.Location = new System.Drawing.Point(238, 33);
            this.listTraseras.Name = "listTraseras";
            this.listTraseras.Size = new System.Drawing.Size(101, 186);
            this.listTraseras.TabIndex = 0;
            // 
            // listFrontales
            // 
            this.listFrontales.FormattingEnabled = true;
            this.listFrontales.Location = new System.Drawing.Point(12, 33);
            this.listFrontales.Name = "listFrontales";
            this.listFrontales.Size = new System.Drawing.Size(101, 186);
            this.listFrontales.TabIndex = 1;
            // 
            // btnCargar
            // 
            this.btnCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Location = new System.Drawing.Point(120, 58);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(113, 30);
            this.btnCargar.TabIndex = 2;
            this.btnCargar.Text = "Cargar Excel";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Enabled = false;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(120, 146);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(112, 47);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // lblFront
            // 
            this.lblFront.AutoSize = true;
            this.lblFront.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFront.Location = new System.Drawing.Point(26, 9);
            this.lblFront.Name = "lblFront";
            this.lblFront.Size = new System.Drawing.Size(73, 16);
            this.lblFront.TabIndex = 4;
            this.lblFront.Text = "Frontales";
            // 
            // lblTras
            // 
            this.lblTras.AutoSize = true;
            this.lblTras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTras.Location = new System.Drawing.Point(253, 9);
            this.lblTras.Name = "lblTras";
            this.lblTras.Size = new System.Drawing.Size(71, 16);
            this.lblTras.TabIndex = 5;
            this.lblTras.Text = "Traseros";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 271);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(327, 16);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 228);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "label1";
            this.lblStatus.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 292);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblTras);
            this.Controls.Add(this.lblFront);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.listFrontales);
            this.Controls.Add(this.listTraseras);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 330);
            this.MinimumSize = new System.Drawing.Size(370, 330);
            this.Name = "Form1";
            this.Text = "Reporter v0.53";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label lblFront;
        private System.Windows.Forms.Label lblTras;
        public System.Windows.Forms.ListBox listTraseras;
        public System.Windows.Forms.ListBox listFrontales;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label lblStatus;
    }
}

