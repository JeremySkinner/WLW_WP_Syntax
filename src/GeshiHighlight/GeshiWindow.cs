using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeshiHighlight {
	public partial class GeshiWindow : Form {
		public GeshiWindow(Settings settings) {
			InitializeComponent();
			SourceCode = settings.SourceCode;
			Language = string.IsNullOrEmpty(settings.Language) ? "csharp" : settings.Language;
			sourceCode.Focus();

		}

		private void okButton_Click(object sender, EventArgs e) {
			string error = "";

			if(string.IsNullOrEmpty(sourceCode.Text)) {
				error += "Please enter some source code.";
			}

			if(string.IsNullOrEmpty(Language)) {
				error += "Please enter a language";
			}

			if(! string.IsNullOrEmpty(error)) {
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		public string SourceCode {
			get { return this.sourceCode.Text; }
			protected set { sourceCode.Text = value; }
		}

		public string Language {
			get { return (string) this.languageComboBox.SelectedItem; }
			protected set { languageComboBox.SelectedItem = value; }
		}

		private void cancelButton_Click(object sender, EventArgs e) {

			if(!string.IsNullOrEmpty(sourceCode.Text)) {
				var result = MessageBox.Show("You have entered some text. Are you sure you want to cancel?", "", MessageBoxButtons.YesNo);
				if(result != DialogResult.Yes) {
					return;
				}
			}

			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void GeshiWindow_Load(object sender, EventArgs e) {
			sourceCode.Focus();
		}
	}
}
