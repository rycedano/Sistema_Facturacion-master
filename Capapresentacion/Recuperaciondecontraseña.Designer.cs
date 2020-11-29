namespace Capapresentacion
{
    partial class Recuperaciondecontraseña
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
            this.Txtemail = new System.Windows.Forms.TextBox();
            this.Lblmensaje = new System.Windows.Forms.Label();
            this.Btnenter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Txtasunto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Txtemail
            // 
            this.Txtemail.Location = new System.Drawing.Point(100, 95);
            this.Txtemail.Name = "Txtemail";
            this.Txtemail.Size = new System.Drawing.Size(222, 20);
            this.Txtemail.TabIndex = 0;
            // 
            // Lblmensaje
            // 
            this.Lblmensaje.AutoSize = true;
            this.Lblmensaje.Location = new System.Drawing.Point(36, 98);
            this.Lblmensaje.Name = "Lblmensaje";
            this.Lblmensaje.Size = new System.Drawing.Size(41, 13);
            this.Lblmensaje.TabIndex = 1;
            this.Lblmensaje.Text = "Correo:";
            // 
            // Btnenter
            // 
            this.Btnenter.Location = new System.Drawing.Point(156, 290);
            this.Btnenter.Name = "Btnenter";
            this.Btnenter.Size = new System.Drawing.Size(75, 23);
            this.Btnenter.TabIndex = 2;
            this.Btnenter.Text = "&Send";
            this.Btnenter.UseVisualStyleBackColor = true;
            this.Btnenter.Click += new System.EventHandler(this.Btnenter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Asunto:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Txtasunto
            // 
            this.Txtasunto.Location = new System.Drawing.Point(100, 154);
            this.Txtasunto.Name = "Txtasunto";
            this.Txtasunto.Size = new System.Drawing.Size(222, 20);
            this.Txtasunto.TabIndex = 3;
            // 
            // Recuperaciondecontraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 336);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txtasunto);
            this.Controls.Add(this.Btnenter);
            this.Controls.Add(this.Lblmensaje);
            this.Controls.Add(this.Txtemail);
            this.Name = "Recuperaciondecontraseña";
            this.Text = "Recuperaciondecontraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txtemail;
        private System.Windows.Forms.Label Lblmensaje;
        private System.Windows.Forms.Button Btnenter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txtasunto;
    }
}