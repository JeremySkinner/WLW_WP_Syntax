namespace GeshiHighlight {
	using System.Windows.Forms;
	using WindowsLive.Writer.Api;

	public class PluginContentEditor : SmartContentEditor {
		private System.Windows.Forms.LinkLabel editCodeLink;

		public PluginContentEditor() {
			InitializeComponent();
		}

		private void InitializeComponent() {
			this.editCodeLink = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// editCodeLink
			// 
			this.editCodeLink.AutoSize = true;
			this.editCodeLink.Location = new System.Drawing.Point(3, 10);
			this.editCodeLink.Name = "editCodeLink";
			this.editCodeLink.Size = new System.Drawing.Size(53, 13);
			this.editCodeLink.TabIndex = 1;
			this.editCodeLink.TabStop = true;
			this.editCodeLink.Text = "Edit Code";
			this.editCodeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editCodeLink_LinkClicked);
			// 
			// PluginContentEditor
			// 
			this.Controls.Add(this.editCodeLink);
			this.Name = "PluginContentEditor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void editCodeLink_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			var settings = new Settings(SelectedContent.Properties);

			using (var form = new GeshiWindow(settings)) {
				var result = form.ShowDialog();

				if (result == DialogResult.OK) {
					settings.SourceCode = form.SourceCode;
					settings.Language = form.Language;
				}

				OnContentEdited();
			}
		}
	}
}