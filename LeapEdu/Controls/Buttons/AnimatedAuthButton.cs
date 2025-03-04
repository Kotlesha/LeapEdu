using CommunityToolkit.Maui.Behaviors;

namespace LeapEdu.Controls.Buttons;

internal partial class AnimatedAuthButton : Button
{
    public AnimatedAuthButton()
    {
        var touchBehavior = new TouchBehavior
        {
            DefaultAnimationEasing = Easing.Linear,
            DefaultAnimationDuration = 100,
            PressedOpacity = 0.3,
            PressedScale = 0.8
        };

        Behaviors.Add(touchBehavior);
    }
}
