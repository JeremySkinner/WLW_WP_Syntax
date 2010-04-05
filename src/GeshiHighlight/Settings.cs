namespace GeshiHighlight {
	using System.Text;
	using System.Web;
	using WindowsLive.Writer.Api;

	public class Settings {
		IProperties props;

		public Settings(IProperties props) {
			this.props = props;
		}

		public string Language {
			get {
				return props.GetString("__Language", string.Empty);
			}
			set {
				props.SetString("__Language", value);
			}
		}

		public string SourceCode {
			get {
				return props.GetString("__Source", string.Empty);
			}
			set {
				props.SetString("__Source", value);
			}
		}

		public string BuildHtmlForEditor() {
			if (string.IsNullOrEmpty(SourceCode)) return string.Empty;

			return "<pre>" + HttpUtility.HtmlEncode(SourceCode) + "</pre>";
		}

		public string BuildHtmlForPublishing() {

			if (string.IsNullOrEmpty(SourceCode)) return string.Empty;

			var output = new StringBuilder();
			output.AppendFormat("<pre lang=\"{0}\">", Language);

			output.Append(SourceCode);

			output.Append("</pre>");
			return output.ToString();
		}
	}
}