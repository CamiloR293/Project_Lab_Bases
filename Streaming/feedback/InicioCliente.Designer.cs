namespace Streaming
{
    partial class InicioCliente
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.btnRecomendados = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnAddMetodosPago = new System.Windows.Forms.Button();
            this.btnDatosPersonales = new System.Windows.Forms.Button();
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.banner = new System.Windows.Forms.Panel();
            this.picBoxBuscar = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlLateral.SuspendLayout();
            this.banner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlMain.Controls.Add(this.pnlDesktop);
            this.pnlMain.Controls.Add(this.pnlLateral);
            this.pnlMain.Controls.Add(this.banner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 512);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(155, 70);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(645, 442);
            this.pnlDesktop.TabIndex = 3;
            this.pnlDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDesktop_Paint);
            // 
            // pnlLateral
            // 
            this.pnlLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(76)))));
            this.pnlLateral.Controls.Add(this.btnRecomendados);
            this.pnlLateral.Controls.Add(this.btnCerrarSesion);
            this.pnlLateral.Controls.Add(this.btnAddMetodosPago);
            this.pnlLateral.Controls.Add(this.btnDatosPersonales);
            this.pnlLateral.Controls.Add(this.btnMenuPrincipal);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 70);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(155, 442);
            this.pnlLateral.TabIndex = 2;
            // 
            // btnRecomendados
            // 
            this.btnRecomendados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecomendados.FlatAppearance.BorderSize = 0;
            this.btnRecomendados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecomendados.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecomendados.ForeColor = System.Drawing.Color.White;
            this.btnRecomendados.Location = new System.Drawing.Point(0, 228);
            this.btnRecomendados.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecomendados.Name = "btnRecomendados";
            this.btnRecomendados.Size = new System.Drawing.Size(155, 76);
            this.btnRecomendados.TabIndex = 4;
            this.btnRecomendados.Text = "RECOMENDADOS";
            this.btnRecomendados.UseVisualStyleBackColor = true;
            this.btnRecomendados.Click += new System.EventHandler(this.btnRecomendados_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(108)))), ((int)(((byte)(56)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 357);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(155, 85);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "CERRAR SESION";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnAddMetodosPago
            // 
            this.btnAddMetodosPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddMetodosPago.FlatAppearance.BorderSize = 0;
            this.btnAddMetodosPago.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(108)))), ((int)(((byte)(56)))));
            this.btnAddMetodosPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMetodosPago.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMetodosPago.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddMetodosPago.Location = new System.Drawing.Point(0, 152);
            this.btnAddMetodosPago.Name = "btnAddMetodosPago";
            this.btnAddMetodosPago.Size = new System.Drawing.Size(155, 76);
            this.btnAddMetodosPago.TabIndex = 2;
            this.btnAddMetodosPago.Text = "AÑADIR METODOS DE PAGO";
            this.btnAddMetodosPago.UseVisualStyleBackColor = true;
            this.btnAddMetodosPago.Click += new System.EventHandler(this.btnAddMetodosPago_Click);
            // 
            // btnDatosPersonales
            // 
            this.btnDatosPersonales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDatosPersonales.FlatAppearance.BorderSize = 0;
            this.btnDatosPersonales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(108)))), ((int)(((byte)(56)))));
            this.btnDatosPersonales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatosPersonales.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatosPersonales.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDatosPersonales.Location = new System.Drawing.Point(0, 76);
            this.btnDatosPersonales.Name = "btnDatosPersonales";
            this.btnDatosPersonales.Size = new System.Drawing.Size(155, 76);
            this.btnDatosPersonales.TabIndex = 1;
            this.btnDatosPersonales.Text = "DATOS PERSONALES";
            this.btnDatosPersonales.UseVisualStyleBackColor = true;
            this.btnDatosPersonales.Click += new System.EventHandler(this.btnDatosPersonales_Click);
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuPrincipal.FlatAppearance.BorderSize = 0;
            this.btnMenuPrincipal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(108)))), ((int)(((byte)(56)))));
            this.btnMenuPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPrincipal.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPrincipal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(155, 76);
            this.btnMenuPrincipal.TabIndex = 0;
            this.btnMenuPrincipal.Text = "MENU PRINCIPAL";
            this.btnMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.btnMenuPrincipal_Click);
            // 
            // banner
            // 
            this.banner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(76)))));
            this.banner.Controls.Add(this.picBoxBuscar);
            this.banner.Controls.Add(this.txtBuscar);
            this.banner.Controls.Add(this.lblTitle);
            this.banner.Dock = System.Windows.Forms.DockStyle.Top;
            this.banner.Location = new System.Drawing.Point(0, 0);
            this.banner.Name = "banner";
            this.banner.Size = new System.Drawing.Size(800, 70);
            this.banner.TabIndex = 1;
            // 
            // picBoxBuscar
            // 
            this.picBoxBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxBuscar.BackColor = System.Drawing.Color.White;
            this.picBoxBuscar.Image = global::Streaming.Properties.Resources.browse;
            this.picBoxBuscar.Location = new System.Drawing.Point(744, 24);
            this.picBoxBuscar.Name = "picBoxBuscar";
            this.picBoxBuscar.Size = new System.Drawing.Size(32, 28);
            this.picBoxBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxBuscar.TabIndex = 25;
            this.picBoxBuscar.TabStop = false;
            this.picBoxBuscar.Click += new System.EventHandler(this.picBoxBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(76)))));
            this.txtBuscar.Location = new System.Drawing.Point(310, 24);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(428, 28);
            this.txtBuscar.TabIndex = 24;
            this.txtBuscar.Text = "Buscar";
            this.txtBuscar.Click += new System.EventHandler(this.txtBuscar_Click);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(61, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(141, 27);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.Text = "StreamingBD";
            // 
            // InicioCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 512);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InicioCliente";
            this.Text = "InicioDelCliente";
            this.Load += new System.EventHandler(this.InicioCliente_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlLateral.ResumeLayout(false);
            this.banner.ResumeLayout(false);
            this.banner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBuscar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel banner;
        private System.Windows.Forms.PictureBox picBoxBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLateral;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnAddMetodosPago;
        private System.Windows.Forms.Button btnDatosPersonales;
        private System.Windows.Forms.Button btnMenuPrincipal;
        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Button btnRecomendados;
        //private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}