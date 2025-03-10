using Android;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.Button;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEdu.Platforms.Android.Handlers;

public class AnimatedAuthButtonHandler : ButtonHandler
{
    protected override MaterialButton CreatePlatformView()
    {
        var button = base.CreatePlatformView();

        button.SetRippleColorResource(Resource.Drawable.leap_edu_ripple);

        return button;
    }
}
