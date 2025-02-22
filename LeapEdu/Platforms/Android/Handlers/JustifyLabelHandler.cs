using Android.OS;
using Android.Text;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Handlers;

namespace LeapEdu.Platforms.Android.Handlers;

internal class JustifyLabelHandler : LabelHandler
{
    public static new IPropertyMapper<ILabel, LabelHandler> Mapper =
        new PropertyMapper<ILabel, LabelHandler>(LabelHandler.Mapper)
        {
            [nameof(ILabel.HorizontalTextAlignment)] = MapHorizontalTextAlignment,
            [nameof(ILabel.Text)] = MapText
        };

    public JustifyLabelHandler() : base(Mapper) { }

    protected override AppCompatTextView CreatePlatformView()
    {
        var textView = base.CreatePlatformView();
        ApplyJustification(textView);
        return textView;
    }

    private static void ApplyJustification(TextView textView)
    {
        if (textView.Context is null) return;

        if (Build.VERSION.SdkInt >= BuildVersionCodes.M && Build.VERSION.SdkInt < BuildVersionCodes.O)
            textView.BreakStrategy = BreakStrategy.Balanced;

        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            textView.JustificationMode = JustificationMode.InterWord;
    }

    private static void MapHorizontalTextAlignment(LabelHandler handler, ILabel label)
    {
        LabelHandler.Mapper.UpdateProperty(handler, label, nameof(ILabel.HorizontalTextAlignment));
        ApplyJustification(handler.PlatformView);
    }

    private static void MapText(LabelHandler handler, ILabel label)
    {
        LabelHandler.Mapper.UpdateProperty(handler, label, nameof(ILabel.Text));
        ApplyJustification(handler.PlatformView);
    }
}
