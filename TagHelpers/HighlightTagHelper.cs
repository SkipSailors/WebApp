namespace WebApp.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("*", Attributes = "[highlight=true")]
public class HighlightTagHelper : TagHelper
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.PreContent.SetHtmlContent("<b><i>");
        output.PostContent.SetHtmlContent("</i></b>");
    }
}