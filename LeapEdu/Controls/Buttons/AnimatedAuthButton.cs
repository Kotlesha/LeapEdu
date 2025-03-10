namespace LeapEdu.Controls.Buttons;

internal partial class AnimatedAuthButton : Button
{
    private const double startScale = 0.7;
    private const double endScale = 1.0;
    private const uint length = 100;

    public AnimatedAuthButton()
    {
        Pressed += OnButtonPressed;
        Released += OnButtonReleased;
    }

    private async void OnButtonPressed(object? sender, EventArgs e) =>
        await this.ScaleTo(startScale, length, Easing.Linear);

    private async void OnButtonReleased(object? sender, EventArgs e) =>
        await this.ScaleTo(endScale, length, Easing.Linear);

    protected override void OnParentSet()
    {
        base.OnParentSet();

        if (Parent is not null) return;

        Pressed -= OnButtonPressed;
        Released -= OnButtonReleased;
    }
}