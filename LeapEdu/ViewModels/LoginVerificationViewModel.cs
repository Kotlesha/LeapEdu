using LeapEdu.Services.Interfaces;
using LeapEdu.Validation;
using LeapEdu.ViewModels.Base;
using System.Net;

namespace LeapEdu.ViewModels;

public partial class LoginVerificationViewModel : BaseNavigationModel, IQueryAttributable
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

    public LoginVerificationViewModel(IDispatcherProvider dispatcher, INavigationService navigationService)
        : base(navigationService)
    {
        _timer = dispatcher.GetForCurrentThread()!.CreateTimer();
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

    private void Timer_Tick(object? sender, EventArgs e)
    {
        RemainingSeconds--;

        if (RemainingSeconds > 0) return;

        _timer.Stop();
        IsRetryButtonEnabled = true;
    }

    public void RestartTimer() => StartTimer();

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Email", out var email)) Email = (string)email;
    }
}
