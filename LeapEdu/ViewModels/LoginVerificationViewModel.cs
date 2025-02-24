using CommunityToolkit.Mvvm.ComponentModel;
using LeapEdu.Validation;
using System.Net;

namespace LeapEdu.ViewModels;

[QueryProperty(nameof(Email), "Email")]
public class LoginVerificationViewModel : ObservableObject
{
    private string _email;
    private string _code;
    private int _remainingSeconds;
    private bool _isRetryButtonEnabled;

    private readonly IDispatcherTimer _timer;

    public int RemainingSeconds
    {
        get => _remainingSeconds;
        set => SetProperty(ref _remainingSeconds, value);
    }

    public string Email
    {
        get => _email;
        set
        {
            var encodedEmail = WebUtility.UrlDecode(value);
            SetProperty(ref _email, encodedEmail);
        }
    }

    public string Code
    {
        get => _code;
        set
        {
            if (SetProperty(ref _code, value))
                OnPropertyChanged(nameof(IsCodeComplete));
        }
    }

    public bool IsRetryButtonEnabled
    {
        get => _isRetryButtonEnabled;
        private set => SetProperty(ref _isRetryButtonEnabled, value);
    }

    public bool IsCodeComplete => Code?.Length == ValidationConstants.CodeLength;

    public LoginVerificationViewModel(IDispatcherProvider dispatcher)
    {
        _timer = dispatcher.GetForCurrentThread().CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(TimerConstants.TimerIntervalInSeconds);
        _timer.Tick += Timer_Tick;

        StartTimer();
    }

    public void StartTimer()
    {
        RemainingSeconds = TimerConstants.RemainingTimeInSeconds;
        IsRetryButtonEnabled = false;
        _timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        RemainingSeconds--;

        if (RemainingSeconds > 0) return;

        _timer.Stop();
        IsRetryButtonEnabled = true;
    }

    public void RestartTimer() => StartTimer();
}
