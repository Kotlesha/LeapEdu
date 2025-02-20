using CommunityToolkit.Maui.Behaviors;

namespace LeapEdu.Controls.Buttons;

internal partial class AnimatedAuthImageButton : ImageButton
{
    public AnimatedAuthImageButton()
    {
        var touchBehavior = new ImageTouchBehavior
        {
            DefaultAnimationEasing = Easing.Linear,
            DefaultAnimationDuration = 100,
            PressedOpacity = 0.3,
            PressedScale = 0.8
        };

        Behaviors.Add(touchBehavior);
    }
}
