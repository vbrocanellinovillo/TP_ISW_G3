namespace TP_ISW_G3.Interfaces
{
    partial class frmDireccion
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
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.cmbCiudades = new System.Windows.Forms.ComboBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtNro = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(28, 127);
            this.txtCalle.Margin = new System.Windows.Forms.Padding(2);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(76, 20);
            this.txtCalle.TabIndex = 1;
            this.txtCalle.TextChanged += new System.EventHandler(this.txtCalle_TextChanged);
            this.txtCalle.Leave += new System.EventHandler(this.txtCalle_Leave);
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(28, 326);
            this.txtReferencia.Margin = new System.Windows.Forms.Padding(2);
            this.txtReferencia.Multiline = true;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(175, 88);
            this.txtReferencia.TabIndex = 4;
            // 
            // cmbCiudades
            // 
            this.cmbCiudades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudades.FormattingEnabled = true;
            this.cmbCiudades.Location = new System.Drawing.Point(28, 258);
            this.cmbCiudades.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCiudades.Name = "cmbCiudades";
            this.cmbCiudades.Size = new System.Drawing.Size(92, 21);
            this.cmbCiudades.TabIndex = 3;
            this.cmbCiudades.SelectedIndexChanged += new System.EventHandler(this.cmbCiudades_SelectedIndexChanged);
            this.cmbCiudades.Leave += new System.EventHandler(this.cmbCiudades_Leave);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = global::TP_ISW_G3.Properties.Resources.btnDirEntrega;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(80, 452);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 66);
            this.btnNext.TabIndex = 5;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtNro
            // 
            this.txtNro.Location = new System.Drawing.Point(28, 193);
            this.txtNro.Mask = "99999";
            this.txtNro.Name = "txtNro";
            this.txtNro.Size = new System.Drawing.Size(76, 20);
            this.txtNro.TabIndex = 2;
            this.txtNro.ValidatingType = typeof(int);
            this.txtNro.TextChanged += new System.EventHandler(this.txtNro_TextChanged);
            this.txtNro.Leave += new System.EventHandler(this.txtNro_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Image = global::TP_ISW_G3.Properties.Resources.direccionComercio;
            this.label5.Location = new System.Drawing.Point(25, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Image = global::TP_ISW_G3.Properties.Resources.direccionComercio;
            this.label6.Location = new System.Drawing.Point(25, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "label6";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Image = global::TP_ISW_G3.Properties.Resources.direccionEntrega;
            this.label7.Location = new System.Drawing.Point(25, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // frmDireccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP_ISW_G3.Properties.Resources.dirComercio;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(295, 529);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNro);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.cmbCiudades);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.txtCalle);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmDireccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dirección";
            this.Load += new System.EventHandler(this.frmDireccionComercio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.ComboBox cmbCiudades;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.MaskedTextBox txtNro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}