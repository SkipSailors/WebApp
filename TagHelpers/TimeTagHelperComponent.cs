namespace WebApp.TagHelpers
{
    using System.Globalization;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    public class TimeTagHelperComponent:TagHelperComponent
    {
        /// <inheritdoc />
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string timestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            if (output.TagName == "body")
            {
                TagBuilder elem = new("div");
                elem.Attributes.Add("class", "bg-info text-white m-2 p-2");
                elem.InnerHtml.Append($"Time:{timestamp}");
                output.PreContent.AppendHtml(elem);
            }
        }
    }
}
