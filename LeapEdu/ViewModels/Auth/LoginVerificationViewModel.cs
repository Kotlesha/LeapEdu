using CommunityToolkit.Mvvm.ComponentModel;
using LeapEdu.Services.Interfaces;
using LeapEdu.Validation;
using LeapEdu.ViewModels.Base;
using System.Net;

namespace LeapEdu.ViewModels.Auth;

public partial class LoginVerificationViewModel : BaseNavigationModel, IQueryAttributable
{
    [ObservableProperty]
    private string email;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsCodeComplete))]
    private string code;

    [ObservableProperty]
    private int remainingSeconds;

    [ObservableProperty]
    private bool isRetryButtonEnabled;

    private readonly IDispatcherTimer _timer;

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
        if (query.TryGetValue("Email", out var email)) 
            Email = WebUtility.UrlDecode((string)email); 
    }
}
