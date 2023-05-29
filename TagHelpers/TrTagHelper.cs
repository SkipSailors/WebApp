namespace WebApp.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;

public class TrTagHelper : TagHelper
{
    public string BgColor { get; set; }
    public string TextColor { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.SetAttribute("class", $"bg-{BgColor} text-center text-{TextColor}");
    }
}