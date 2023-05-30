namespace WebApp.TagHelpers;

using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("table")]
public class TableFooterSelector : TagHelperComponentTagHelper
{
    /// <inheritdoc />
    public TableFooterSelector(
        ITagHelperComponentManager mgr,
        ILoggerFactory log) : base(mgr, log)
    {
    }
}

[HtmlTargetElement("table")]
public class TableFooterTagHelperComponent : TagHelperComponent
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (output.TagName == "table")
        {
            TagBuilder cell = new("td");
            cell.Attributes.Add("colspan", "2");
            cell.Attributes.Add("class", "bg-dark text-white text-center");
            cell.InnerHtml.Append("Table Footer");
            TagBuilder row = new("tr");
            row.InnerHtml.AppendHtml(cell);
            TagBuilder footer = new("tfoot");
            footer.InnerHtml.AppendHtml(row);
            output.PostContent.AppendHtml(footer);
        }
    }
}