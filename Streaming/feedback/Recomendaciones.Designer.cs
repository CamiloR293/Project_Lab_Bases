namespace Streaming.feedback
{
    partial class Recomendaciones
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
            this.flowPanelPeliculasRelacionadas = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowPanelPeliculasRelacionadas
            // 
            this.flowPanelPeliculasRelacionadas.AutoScroll = true;
            this.flowPanelPeliculasRelacionadas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowPanelPeliculasRelacionadas.Location = new System.Drawing.Point(0, 3);
            this.flowPanelPeliculasRelacionadas.Name = "flowPanelPeliculasRelacionadas";
            this.flowPanelPeliculasRelacionadas.Size = new System.Drawing.Size(613, 484);
            this.flowPanelPeliculasRelacionadas.TabIndex = 29;
            this.flowPanelPeliculasRelacionadas.Paint += new System.Windows.Forms.PaintEventHandler(this.flowPanelPeliculasRelacionadas_Paint);
            // 
            // Recomendaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 487);
            this.Controls.Add(this.flowPanelPeliculasRelacionadas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Recomendaciones";
            this.Text = "Recomendaciones";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowPanelPeliculasRelacionadas;
    }
}