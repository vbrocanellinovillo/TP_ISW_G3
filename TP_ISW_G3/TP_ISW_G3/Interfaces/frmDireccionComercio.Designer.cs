namespace TP_ISW_G3.Interfaces
{
    partial class frmDireccionComercio
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
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtNro = new System.Windows.Forms.TextBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.cmbCiudades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDireccionEntrega = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(42, 71);
            this.txtCalle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(76, 20);
            this.txtCalle.TabIndex = 0;
            // 
            // txtNro
            // 
            this.txtNro.Location = new System.Drawing.Point(42, 118);
            this.txtNro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNro.Name = "txtNro";
            this.txtNro.Size = new System.Drawing.Size(76, 20);
            this.txtNro.TabIndex = 1;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(46, 222);
            this.txtReferencia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReferencia.Multiline = true;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(175, 88);
            this.txtReferencia.TabIndex = 2;
            // 
            // cmbCiudades
            // 
            this.cmbCiudades.FormattingEnabled = true;
            this.cmbCiudades.Location = new System.Drawing.Point(42, 167);
            this.cmbCiudades.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCiudades.Name = "cmbCiudades";
            this.cmbCiudades.Size = new System.Drawing.Size(92, 21);
            this.cmbCiudades.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Calle *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Numero *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ciudad *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Referencia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Direccion Comercio";
            // 
            // btnDireccionEntrega
            // 
            this.btnDireccionEntrega.Location = new System.Drawing.Point(73, 362);
            this.btnDireccionEntrega.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDireccionEntrega.Name = "btnDireccionEntrega";
            this.btnDireccionEntrega.Size = new System.Drawing.Size(108, 51);
            this.btnDireccionEntrega.TabIndex = 9;
            this.btnDireccionEntrega.Text = "Ir a direccion de entrega";
            this.btnDireccionEntrega.UseVisualStyleBackColor = true;
            this.btnDireccionEntrega.Click += new System.EventHandler(this.btnDireccionEntrega_Click);
            // 
            // frmDireccionComercio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 478);
            this.Controls.Add(this.btnDireccionEntrega);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCiudades);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.txtNro);
            this.Controls.Add(this.txtCalle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmDireccionComercio";
            this.Text = "frmDireccion";
            this.Load += new System.EventHandler(this.frmDireccionComercio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtNro;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.ComboBox cmbCiudades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDireccionEntrega;
    }
}