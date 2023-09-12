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
            this.btnAntes.BackgroundImage = global::TP_ISW_G3.Properties.Resources.btnAntesPosible;
            this.btnAntes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAntes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAntes.FlatAppearance.BorderSize = 0;
            this.btnAntes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAntes.Location = new System.Drawing.Point(88, 273);
            this.btnAntes.Margin = new System.Windows.Forms.Padding(2);
            this.btnAntes.Name = "btnAntes";
            this.btnAntes.Size = new System.Drawing.Size(125, 65);
            this.btnAntes.TabIndex = 1;
            this.btnAntes.UseVisualStyleBackColor = true;
            this.btnAntes.Click += new System.EventHandler(this.btnAntes_Click);
            // 
            // btnFechaHora
            // 
            this.btnFechaHora.BackgroundImage = global::TP_ISW_G3.Properties.Resources.btnFechaYHora;
            this.btnFechaHora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFechaHora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechaHora.FlatAppearance.BorderSize = 0;
            this.btnFechaHora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechaHora.Location = new System.Drawing.Point(88, 352);
            this.btnFechaHora.Margin = new System.Windows.Forms.Padding(2);
            this.btnFechaHora.Name = "btnFechaHora";
            this.btnFechaHora.Size = new System.Drawing.Size(125, 64);
            this.btnFechaHora.TabIndex = 2;
            this.btnFechaHora.UseVisualStyleBackColor = true;
            this.btnFechaHora.Click += new System.EventHandler(this.btnFechaHora_Click);
            // 
            // frmEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP_ISW_G3.Properties.Resources._20230911_175442_0001;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(295, 529);
            this.Controls.Add(this.btnFechaHora);
            this.Controls.Add(this.btnAntes);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmEntrega";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrega";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAntes;
        private System.Windows.Forms.Button btnFechaHora;
    }
}