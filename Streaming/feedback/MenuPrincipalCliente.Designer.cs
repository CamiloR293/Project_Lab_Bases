using Streaming.logica;

namespace Streaming
{
    partial class MenuPrincipalCliente
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
            this.flowPanelCatalogo = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.cmbBoxGenero = new System.Windows.Forms.ComboBox();
            this.pnlDesktop.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlDesktop.Controls.Add(this.flowPanelCatalogo);
            this.pnlDesktop.Controls.Add(this.pnlBanner);
            this.pnlDesktop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(0, 0);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(645, 491);
            this.pnlDesktop.TabIndex = 0;
            // 
            // flowPanelCatalogo
            // 
            this.flowPanelCatalogo.AutoScroll = true;
            this.flowPanelCatalogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelCatalogo.Location = new System.Drawing.Point(0, 40);
            this.flowPanelCatalogo.Name = "flowPanelCatalogo";
            this.flowPanelCatalogo.Size = new System.Drawing.Size(645, 451);
            this.flowPanelCatalogo.TabIndex = 1;
            this.flowPanelCatalogo.Paint += new System.Windows.Forms.PaintEventHandler(this.flowPanelCatalogo_Paint);
            // 
            // pnlBanner
            // 
            this.pnlBanner.Controls.Add(this.cmbBoxGenero);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(645, 40);
            this.pnlBanner.TabIndex = 0;
            // 
            // cmbBoxGenero
            // 
            this.cmbBoxGenero.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoxGenero.FormattingEnabled = true;
            this.cmbBoxGenero.Location = new System.Drawing.Point(12, 6);
            this.cmbBoxGenero.Name = "cmbBoxGenero";
            this.cmbBoxGenero.Size = new System.Drawing.Size(160, 28);
            this.cmbBoxGenero.TabIndex = 0;
            this.cmbBoxGenero.Text = "Genero";
            this.cmbBoxGenero.SelectedIndexChanged += new System.EventHandler(this.cmbBoxGenero_SelectedIndexChanged);
            // 
            // MenuPrincipalCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 491);
            this.Controls.Add(this.pnlDesktop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuPrincipalCliente";
            this.Text = "MenuPrincipalCliente";
            this.pnlDesktop.ResumeLayout(false);
            this.pnlBanner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDesktop;
        //private Pelicula picBoxPeliculaC;
        private System.Windows.Forms.FlowLayoutPanel flowPanelCatalogo;
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.ComboBox cmbBoxGenero;
    }
}