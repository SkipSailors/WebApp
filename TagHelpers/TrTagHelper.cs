﻿namespace WebApp.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("tr", Attributes = "bg-color,text-color")]
[HtmlTargetElement("td", Attributes = "bg-color")]
public class TrTagHelper : TagHelper
{
    public string BgColor { get; set; } = "dark";
    public string TextColor { get; set; } = "white";

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.SetAttribute("class", $"bg-{BgColor} text-center text-{TextColor}");
    }
}