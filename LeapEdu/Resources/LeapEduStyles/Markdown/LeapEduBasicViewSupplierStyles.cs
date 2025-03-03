using Plugin.Maui.MarkdownView.ViewSuppliers;

namespace LeapEdu.Resources.LeapEduStyles.Markdown;

public class LeapEduBasicViewSupplierStyles : MauiBasicViewSupplierStyles
{
    public LeapEduBasicViewSupplierStyles() => LoadDefaultStylesIn(this);

    public static void LoadDefaultStylesIn(MauiBasicViewSupplierStyles styles)
    {
        var resources = Application.Current!.Resources;

        styles.TextViewStyle = (Style)resources["MarkdownTextViewStyle"];
        styles.HeaderViewLevel1Style = (Style)resources["MarkdownHeaderViewLevel1Style"];
        styles.HeaderViewLevel2Style = (Style)resources["MarkdownHeaderViewLevel2Style"];
        styles.HeaderViewLevel3Style = (Style)resources["MarkdownHeaderViewLevel3Style"];
        styles.HeaderViewLevel4Style = (Style)resources["MarkdownHeaderViewLevel4Style"];
        styles.ListItemBulletViewLevel1Style = (Style)resources["MarkdownListItemBulletViewLevel1Style"];
        styles.ListTextViewStyle = (Style)resources["MarkdownListTextViewStyle"];
    }
}
