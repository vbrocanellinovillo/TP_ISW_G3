namespace TP_ISW_G3.Interfaces
{
    partial class frmEntrega
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
            this.btnAntes = new System.Windows.Forms.Button();
            this.btnFechaHora = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAntes
            // 
            this.btnAntes.Location = new System.Drawing.Point(69, 54);
            this.btnAntes.Name = "btnAntes";
            this.btnAntes.Size = new System.Drawing.Size(127, 80);
            this.btnAntes.TabIndex = 0;
            this.btnAntes.Text = "Lo antes posible";
            this.btnAntes.UseVisualStyleBackColor = true;
            this.btnAntes.Click += new System.EventHandler(this.btnAntes_Click);
            // 
            // btnFechaHora
            // 
            this.btnFechaHora.Location = new System.Drawing.Point(69, 149);
            this.btnFechaHora.Name = "btnFechaHora";
            this.btnFechaHora.Size = new System.Drawing.Size(127, 130);
            this.btnFechaHora.TabIndex = 1;
            this.btnFechaHora.Text = "Selecciona fecha y hora";
            this.btnFechaHora.UseVisualStyleBackColor = true;
            this.btnFechaHora.Click += new System.EventHandler(this.btnFechaHora_Click);
            // 
            // frmEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP_ISW_G3.Properties.Resources._20230911_093828_0001;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(276, 488);
            this.Controls.Add(this.btnFechaHora);
            this.Controls.Add(this.btnAntes);
            this.DoubleBuffered = true;
            this.Name = "frmEntrega";
            this.Text = "frmEntrega";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAntes;
        private System.Windows.Forms.Button btnFechaHora;
    }
}