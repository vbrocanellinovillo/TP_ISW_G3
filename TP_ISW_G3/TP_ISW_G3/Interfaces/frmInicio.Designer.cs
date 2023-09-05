namespace TP_ISW_G3
{
    partial class frmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoQueSea = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoQueSea
            // 
            this.btnLoQueSea.Location = new System.Drawing.Point(215, 147);
            this.btnLoQueSea.Name = "btnLoQueSea";
            this.btnLoQueSea.Size = new System.Drawing.Size(105, 83);
            this.btnLoQueSea.TabIndex = 0;
            this.btnLoQueSea.Text = "Lo que sea";
            this.btnLoQueSea.UseVisualStyleBackColor = true;
            this.btnLoQueSea.Click += new System.EventHandler(this.btnLoQueSea_Click);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 640);
            this.Controls.Add(this.btnLoQueSea);
            this.Name = "frmInicio";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoQueSea;
    }
}

