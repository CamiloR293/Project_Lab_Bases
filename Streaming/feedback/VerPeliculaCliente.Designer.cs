namespace Streaming
{
    partial class VerPeliculaCliente
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnVerAhora = new System.Windows.Forms.Button();
            this.lblTituloPelicula = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowPanelPeliculasRelacionadas = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComprar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(108)))), ((int)(((byte)(56)))));
            this.panel1.Controls.Add(this.btnComprar);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Controls.Add(this.btnVerAhora);
            this.panel1.Controls.Add(this.lblTituloPelicula);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 228);
            this.panel1.TabIndex = 0;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDescripcion.Location = new System.Drawing.Point(179, 96);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(408, 112);
            this.lblDescripcion.TabIndex = 26;
            this.lblDescripcion.Text = "DescripcionPelicula";
            // 
            // btnVerAhora
            // 
            this.btnVerAhora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(117)))));
            this.btnVerAhora.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
            this.btnVerAhora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerAhora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerAhora.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerAhora.Location = new System.Drawing.Point(47, 175);
            this.btnVerAhora.Name = "btnVerAhora";
            this.btnVerAhora.Size = new System.Drawing.Size(90, 25);
            this.btnVerAhora.TabIndex = 25;
            this.btnVerAhora.Text = "Ver ahora";
            this.btnVerAhora.UseVisualStyleBackColor = false;
            this.btnVerAhora.Click += new System.EventHandler(this.btnVerAhora_Click);
            // 
            // lblTituloPelicula
            // 
            this.lblTituloPelicula.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTituloPelicula.AutoSize = true;
            this.lblTituloPelicula.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPelicula.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTituloPelicula.Location = new System.Drawing.Point(147, 30);
            this.lblTituloPelicula.Name = "lblTituloPelicula";
            this.lblTituloPelicula.Size = new System.Drawing.Size(146, 27);
            this.lblTituloPelicula.TabIndex = 23;
            this.lblTituloPelicula.Text = "TituloPelicula";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.flowPanelPeliculasRelacionadas);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 228);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 333);
            this.panel2.TabIndex = 1;
            // 
            // flowPanelPeliculasRelacionadas
            // 
            this.flowPanelPeliculasRelacionadas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowPanelPeliculasRelacionadas.Location = new System.Drawing.Point(0, 60);
            this.flowPanelPeliculasRelacionadas.Name = "flowPanelPeliculasRelacionadas";
            this.flowPanelPeliculasRelacionadas.Size = new System.Drawing.Size(613, 273);
            this.flowPanelPeliculasRelacionadas.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(182, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "PELICULAS RELACIONADAS";
            // 
            // btnComprar
            // 
            this.btnComprar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(117)))));
            this.btnComprar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(144)))), ((int)(((byte)(77)))));
            this.btnComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnComprar.Location = new System.Drawing.Point(152, 175);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(90, 25);
            this.btnComprar.TabIndex = 27;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = false;
            this.btnComprar.Visible= false;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // VerPeliculaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "VerPeliculaCliente";
            this.Text = "VerPeliculaCliente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTituloPelicula;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnVerAhora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowPanelPeliculasRelacionadas;
        private System.Windows.Forms.Button btnComprar;
    }
}