﻿namespace TP_ISW_G3
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
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnLoQueSea
            // 
            this.btnLoQueSea.BackgroundImage = global::TP_ISW_G3.Properties.Resources.btn1;
            this.btnLoQueSea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoQueSea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoQueSea.FlatAppearance.BorderSize = 0;
            this.btnLoQueSea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoQueSea.Location = new System.Drawing.Point(108, 302);
            this.btnLoQueSea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoQueSea.Name = "btnLoQueSea";
            this.btnLoQueSea.Size = new System.Drawing.Size(184, 81);
            this.btnLoQueSea.TabIndex = 0;
            this.btnLoQueSea.UseVisualStyleBackColor = true;
            this.btnLoQueSea.Click += new System.EventHandler(this.btnLoQueSea_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::TP_ISW_G3.Properties.Resources.btn2;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(108, 417);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 81);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(91, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP_ISW_G3.Properties.Resources._20230911_095408_0000;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(393, 651);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoQueSea);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliverEat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoQueSea;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

