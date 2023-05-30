namespace WebApp.TagHelpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("tr", Attributes = "for")]
    public class ModelRowTagHelper: TagHelper
    {
        public string Format { get; set; } = string.Empty;
        public ModelExpression? For { get; set; }

        /// <inheritdoc />
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            TagBuilder th = new("th");
            th.InnerHtml.Append(For?.Name.Split(".").Last() ?? string.Empty);
            output.Content.AppendHtml(th);
            TagBuilder td = new("td");
            if (Format != null && For?.Metadata.ModelType == typeof(decimal))
            {
                td.InnerHtml.Append(((decimal)For.Model).ToString());
            }
            else
            {
                td.InnerHtml.Append(For?.Model.ToString() ?? string.Empty);
            }

            output.Content.AppendHtml(td);
        }
    }
}
