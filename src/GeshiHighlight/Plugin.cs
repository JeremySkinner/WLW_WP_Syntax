namespace GeshiHighlight {
	using System;
	using System.Text;
	using System.Web;
	using System.Windows.Forms;
	using WindowsLive.Writer.Api;

	[WriterPlugin("4318B029-7F5A-4155-A9CF-329C469B73B3", "Geshi")]
	[InsertableContentSource("Source Code", SidebarText = "Source Code")]
	public class Plugin : SmartContentSource {

		public override DialogResult CreateContent(IWin32Window dialogOwner, ISmartContent newContent) {
			var settings = new Settings(newContent.Properties);

			using (var form = new GeshiWindow(settings)) {
				var result = form.ShowDialog();

				if (result == DialogResult.OK) {
					settings.SourceCode = form.SourceCode;
					settings.Language = form.Language;
				}

				return result;
			}
		}

		public override string GenerateEditorHtml(ISmartContent content, IPublishingContext publishingContext) {
			var settings = new Settings(content.Properties);
			return settings.BuildHtmlForEditor();
		}

		public override string GeneratePublishHtml(ISmartContent content, IPublishingContext publishingContext) {
			var settings = new Settings(content.Properties);
			return settings.BuildHtmlForPublishing();
		}

		public override SmartContentEditor CreateEditor(ISmartContentEditorSite editorSite) {
			return new PluginContentEditor(); 
		}
	}
}