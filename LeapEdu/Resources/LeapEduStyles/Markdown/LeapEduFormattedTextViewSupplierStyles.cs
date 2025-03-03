using Plugin.Maui.MarkdownView.ViewSuppliers;

namespace LeapEdu.Resources.LeapEduStyles.Markdown;

public class LeapEduFormattedTextViewSupplierStyles : MauiFormattedTextViewSupplierStyles
{
    public LeapEduFormattedTextViewSupplierStyles() => LoadDefaultFormattedTextStylesIn(this);

    public static void LoadDefaultFormattedTextStylesIn(MauiFormattedTextViewSupplierStyles styles)
    {
        var resources = Application.Current!.Resources;

        styles.SpanHyperlinkTextLightColor = (Color)resources["MarkdownSpanHyperlinkTextColorLight"];
    }
}
