﻿namespace WebApp.TagHelpers;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("tablehead")]
public class TableHeadTagHelper : TagHelper
{
    public string BgColor { get; set; } = "light";

    /// <inheritdoc />
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "thead";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.SetAttribute("class", $"bg-{BgColor} text-white text-center");
        string content = (await output.GetChildContentAsync()).GetContent();
        TagBuilder header = new("th")
        {
            Attributes =
            {
                ["colspan"] = "2"
            }
        };
        header.InnerHtml.Append(content);
        TagBuilder row = new("tr");
        row.InnerHtml.AppendHtml(header);
        output.Content.SetHtmlContent(row);
    }
}