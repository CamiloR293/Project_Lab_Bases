namespace Streaming
{
    partial class MainEmpleado
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
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.picBoxReturnTo = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.picBoxPassword = new System.Windows.Forms.PictureBox();
            this.picBoxUserName = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblInicioSesion = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReturnTo)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
            this.pnlDesktop.Controls.Add(this.picBoxReturnTo);
            this.pnlDesktop.Controls.Add(this.pnlMenu);
            this.pnlDesktop.Controls.Add(this.pictureBox3);
            this.pnlDesktop.Controls.Add(this.pictureBox2);
            this.pnlDesktop.Controls.Add(this.pictureBox1);
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDesktop.Location = new System.Drawing.Point(0, 0);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(800, 561);
            this.pnlDesktop.TabIndex = 1;
            // 
            // picBoxReturnTo
            // 
            this.picBoxReturnTo.Image = global::Streaming.Properties.Resources._return;
            this.picBoxReturnTo.Location = new System.Drawing.Point(28, 22);
            this.picBoxReturnTo.Name = "picBoxReturnTo";
            this.picBoxReturnTo.Size = new System.Drawing.Size(49, 50);
            this.picBoxReturnTo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxReturnTo.TabIndex = 9;
            this.picBoxReturnTo.TabStop = false;
            this.picBoxReturnTo.Click += new System.EventHandler(this.picBoxReturnTo_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(110)))), ((int)(((byte)(57)))));
            this.pnlMenu.Controls.Add(this.txtPassword);
            this.pnlMenu.Controls.Add(this.txtUserName);
            this.pnlMenu.Controls.Add(this.btnIngresar);
            this.pnlMenu.Controls.Add(this.picBoxPassword);
            this.pnlMenu.Controls.Add(this.picBoxUserName);
            this.pnlMenu.Controls.Add(this.pictureBox5);
            this.pnlMenu.Controls.Add(this.lblInicioSesion);
            this.pnlMenu.Location = new System.Drawing.Point(180, 116);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(444, 361);
            this.pnlMenu.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(194)))), ((int)(((byte)(157)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPassword.Location = new System.Drawing.Point(33, 141);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(376, 16);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Text = "Contraseña";
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(194)))), ((int)(((byte)(157)))));
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtUserName.Location = new System.Drawing.Point(33, 87);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(376, 16);
            this.txtUserName.TabIndex = 7;
            this.txtUserName.Text = "Correo o nombre de usuario";
            this.txtUserName.Click += new System.EventHandler(this.txtUserName_Click);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIngresar.BackColor = System.Drawing.Color.White;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(110)))), ((int)(((byte)(56)))));
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
            this.btnIngresar.Location = new System.Drawing.Point(161, 208);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(119, 47);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // picBoxPassword
            // 
            this.picBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(194)))), ((int)(((byte)(157)))));
            this.picBoxPassword.Location = new System.Drawing.Point(19, 129);
            this.picBoxPassword.Name = "picBoxPassword";
            this.picBoxPassword.Size = new System.Drawing.Size(400, 38);
            this.picBoxPassword.TabIndex = 3;
            this.picBoxPassword.TabStop = false;
            // 
            // picBoxUserName
            // 
            this.picBoxUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picBoxUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(194)))), ((int)(((byte)(157)))));
            this.picBoxUserName.Location = new System.Drawing.Point(19, 76);
            this.picBoxUserName.Name = "picBoxUserName";
            this.picBoxUserName.Size = new System.Drawing.Size(400, 38);
            this.picBoxUserName.TabIndex = 2;
            this.picBoxUserName.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Streaming.Properties.Resources.square;
            this.pictureBox5.Location = new System.Drawing.Point(19, 47);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(245, 2);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // lblInicioSesion
            // 
            this.lblInicioSesion.AutoSize = true;
            this.lblInicioSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicioSesion.ForeColor = System.Drawing.Color.White;
            this.lblInicioSesion.Location = new System.Drawing.Point(12, 12);
            this.lblInicioSesion.Name = "lblInicioSesion";
            this.lblInicioSesion.Size = new System.Drawing.Size(252, 37);
            this.lblInicioSesion.TabIndex = 0;
            this.lblInicioSesion.Text = "Inicio de sesion";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::Streaming.Properties.Resources.circle1;
            this.pictureBox3.Location = new System.Drawing.Point(711, 401);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(62, 57);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Streaming.Properties.Resources.circle1;
            this.pictureBox2.Location = new System.Drawing.Point(620, 492);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 57);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Streaming.Properties.Resources.circle1;
            this.pictureBox1.Location = new System.Drawing.Point(688, 464);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.pnlDesktop);
            this.Name = "MainEmpleado";
            this.Text = "InicioEmpleado";
            this.pnlDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReturnTo)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.PictureBox picBoxPassword;
        private System.Windows.Forms.PictureBox picBoxUserName;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblInicioSesion;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picBoxReturnTo;
    }
}