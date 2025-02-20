using CommunityToolkit.Maui.Behaviors;

namespace LeapEdu.Controls.Labels;

internal partial class AnimatedLabel : Label
{
    public AnimatedLabel()
    {
        var touchBehavior = new TouchBehavior
        {
            DefaultAnimationEasing = Easing.CubicOut,
            DefaultAnimationDuration = 100,
            PressedOpacity = 0.3,
            PressedScale = 0.8
        };

        Behaviors.Add(touchBehavior);
    }
}
