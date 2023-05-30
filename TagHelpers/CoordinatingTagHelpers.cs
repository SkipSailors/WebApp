﻿namespace WebApp.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("tr", Attributes = "theme")]
public class RowTagHelper : TagHelper
{
    public string Theme { get; set; } = string.Empty;

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        context.Items["theme"] = Theme;
    }
}

[HtmlTargetElement("th")]
[HtmlTargetElement("td")]
public class CellTagHelper : TagHelper
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (context.Items.ContainsKey("theme"))
        {
            output.Attributes.SetAttribute("class", $"bg-{context.Items["theme"]} text-white");
        }
    }
}