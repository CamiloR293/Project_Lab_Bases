using System.Windows.Forms;
using System;
using Streaming.logica;

namespace Streaming
{
    partial class AgregarTarjeta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private void BtnRegistrarme_Click(object sender, EventArgs e)
        {
            // Aquí puedes escribir el código que se ejecutará cuando se haga clic en el botón
            // Por ejemplo, puedes mostrar un mensaje de confirmación
            MessageBox.Show("¡Haz hecho clic en Registrarme!");

            tarjeta mitarjeta = new tarjeta();
            Cliente miCLiente = new Cliente();
            //enviar datos de caja de texto para agregar nuevo usuario
            int resultado = miCLiente.ingresarRegistro(txtUsuario, txtPNombre, txtPApellido,
                txtSNombre, txtSApellido, txtPasswordRegistro, txtFechaNacimiento, txtTelefono
                , txtCorreo);

            //enviar datos de caja de texto para agregar tarjeta
            int resultado2 = mitarjeta.ingresartarjeta(txtNumero.Text, txtFechaExpedicion.Text,
                                                       txtNombre.Text, txtCVV.Text, cmbBoxTipoTarjeta.SelectedItem.ToString());

            //validacion
            if (resultado > 0 && resultado2 > 0)
            {
                MessageBox.Show("Usuario y Tarjeta registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                miCLiente = miCLiente.ObtenerClientePorUsuario(txtUsuario);

                openForms(new PlanSuscripcionCliente(panelContainer, this, miCLiente));

            }
            else
                MessageBox.Show("No se ha completado el proceso satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //limpiar cajas de texto
            txtCVV.Clear();
            txtFechaExpedicion.Clear();
            txtNombre.Clear();
            txtNumero.Clear();
            txtPassword.Clear();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            // Aquí puedes escribir el código que se ejecutará cuando se haga clic en el botón
            // Por ejemplo, puedes mostrar un mensaje de confirmación
            MessageBox.Show("¡Haz hecho clic en Registrar!");

            tarjeta mitarjeta = new tarjeta();



            //enviar datos de caja de texto para agregar tarjeta
            int resultado2 = mitarjeta.ingresartarjetaLogin(cliente.Codigo, txtNumero.Text, txtFechaExpedicion.Text,
                                                       txtNombre.Text, txtCVV.Text, cmbBoxTipoTarjeta.SelectedItem.ToString());

            //validacion
            if (resultado2 > 0)
            {
                MessageBox.Show("Tarjeta registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                openForms(new PlanSuscripcionCliente(panelContainer, this, cliente));
            }
            else
                MessageBox.Show("No se ha completado el proceso satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //limpiar cajas de texto
            txtCVV.Clear();
            txtFechaExpedicion.Clear();
            txtNombre.Clear();
            txtNumero.Clear();
            txtPassword.Clear();
        }

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
            this.picBoxReturnTo = new System.Windows.Forms.PictureBox();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.cmbBoxTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.btnRegistrarme = new System.Windows.Forms.Button();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.txtFechaExpedicion = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReturnTo)).BeginInit();
            this.pnlDesktop.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxReturnTo
            // 
            this.picBoxReturnTo.Image = global::Streaming.Properties.Resources._return;
            this.picBoxReturnTo.Location = new System.Drawing.Point(22, 12);
            this.picBoxReturnTo.Name = "picBoxReturnTo";
            this.picBoxReturnTo.Size = new System.Drawing.Size(49, 50);
            this.picBoxReturnTo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxReturnTo.TabIndex = 0;
            this.picBoxReturnTo.TabStop = false;
            this.picBoxReturnTo.Click += new System.EventHandler(this.picBoxReturnTo_Click);
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(195)))), ((int)(((byte)(156)))));
            this.pnlDesktop.Controls.Add(this.btnRegistrar);
            this.pnlDesktop.Controls.Add(this.cmbBoxTipoTarjeta);
            this.pnlDesktop.Controls.Add(this.btnRegistrarme);
            this.pnlDesktop.Controls.Add(this.txtCVV);
            this.pnlDesktop.Controls.Add(this.txtFechaExpedicion);
            this.pnlDesktop.Controls.Add(this.txtNumero);
            this.pnlDesktop.Controls.Add(this.txtNombre);
            this.pnlDesktop.Controls.Add(this.label7);
            this.pnlDesktop.Controls.Add(this.label6);
            this.pnlDesktop.Controls.Add(this.label5);
            this.pnlDesktop.Controls.Add(this.label2);
            this.pnlDesktop.Controls.Add(this.label1);
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(0, 71);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(590, 390);
            this.pnlDesktop.TabIndex = 3;
            this.pnlDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDesktop_Paint);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(117)))));
            this.btnRegistrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrar.Location = new System.Drawing.Point(223, 321);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(130, 45);
            this.btnRegistrar.TabIndex = 24;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += BtnRegistrar_Click;

            // 
            // cmbBoxTipoTarjeta
            // 
            this.cmbBoxTipoTarjeta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbBoxTipoTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoxTipoTarjeta.FormattingEnabled = true;
            this.cmbBoxTipoTarjeta.Items.AddRange(new object[] {
            "Debito",
            "Credito"});
            this.cmbBoxTipoTarjeta.Location = new System.Drawing.Point(240, 237);
            this.cmbBoxTipoTarjeta.Name = "cmbBoxTipoTarjeta";
            this.cmbBoxTipoTarjeta.Size = new System.Drawing.Size(167, 28);
            this.cmbBoxTipoTarjeta.TabIndex = 23;
            this.cmbBoxTipoTarjeta.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnRegistrarme
            // 
            this.btnRegistrarme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegistrarme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(117)))));
            this.btnRegistrarme.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
            this.btnRegistrarme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarme.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrarme.Location = new System.Drawing.Point(223, 321);
            this.btnRegistrarme.Name = "btnRegistrarme";
            this.btnRegistrarme.Size = new System.Drawing.Size(130, 45);
            this.btnRegistrarme.TabIndex = 21;
            this.btnRegistrarme.Text = "Registrarme";
            this.btnRegistrarme.UseVisualStyleBackColor = false;
            this.btnRegistrarme.Click += BtnRegistrarme_Click;

            // 
            // txtCVV
            // 
            this.txtCVV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCVV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCVV.Location = new System.Drawing.Point(240, 189);
            this.txtCVV.Multiline = true;
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(167, 20);
            this.txtCVV.TabIndex = 16;
            this.txtCVV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCVV_KeyPress);
            this.txtCVV.Leave += new System.EventHandler(this.txtCVV_Leave);
            // 
            // txtFechaExpedicion
            // 
            this.txtFechaExpedicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFechaExpedicion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFechaExpedicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaExpedicion.Location = new System.Drawing.Point(240, 142);
            this.txtFechaExpedicion.Multiline = true;
            this.txtFechaExpedicion.Name = "txtFechaExpedicion";
            this.txtFechaExpedicion.Size = new System.Drawing.Size(167, 20);
            this.txtFechaExpedicion.TabIndex = 15;
            this.txtFechaExpedicion.Leave += new System.EventHandler(this.txtFechaExpedicion_Leave);
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(240, 94);
            this.txtNumero.Multiline = true;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(167, 20);
            this.txtNumero.TabIndex = 12;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(240, 48);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(167, 20);
            this.txtNombre.TabIndex = 11;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(119, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tipo tarjeta:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(175, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "CVV:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha de expiración:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(591, 73);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(167, 20);
            this.txtPassword.TabIndex = 19;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(117)))));
            this.pnlSuperior.Controls.Add(this.lblTitle);
            this.pnlSuperior.Controls.Add(this.picBoxReturnTo);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(590, 71);
            this.pnlSuperior.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(187, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 27);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "REGISTRAR TARJETA";
            // 
            // AgregarTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 461);
            this.Controls.Add(this.pnlDesktop);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AgregarTarjeta";
            this.Text = "AgregarTarjeta";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReturnTo)).EndInit();
            this.pnlDesktop.ResumeLayout(false);
            this.pnlDesktop.PerformLayout();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxReturnTo;
        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Button btnRegistrarme;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.TextBox txtFechaExpedicion;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbBoxTipoTarjeta;
        private System.Windows.Forms.Button btnRegistrar;
    }
}