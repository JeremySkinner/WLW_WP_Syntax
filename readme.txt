This is a very simple Windows Live Writer plugin that integrates with the WP-Syntax Wordpress plugin http://wordpress.org/extend/plugins/wp-syntax/.

WP_Syntax uses the PHP Geshi library to colourise source code. This plugin for Windows Live Writer allows you to edit code samples in a way that is compatible with WP_Syntax, generating markup such as:

<pre lang="csharp">
public class MyValidator : AbstractValidator<Foo> {
  //...
}
</pre>

The solution assumes WLW is installed in C:\Program Files (x86)\Windows Live\Writer and will copy the plugin to 
C:\Program Files (x86)\Windows Live\Writer\Plugins after each build. 

If you are running on x86 windows then you will need to update the reference paths and the post-build step.
