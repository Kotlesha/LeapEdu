using CommunityToolkit.Mvvm.ComponentModel;
using LeapEdu.Helpers;

namespace LeapEdu.ViewModels.Auth;

public partial class LegalNoticiesViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isRunning;

    [ObservableProperty]
    private bool isVisibleText;

    [ObservableProperty]
    private string data;

    private string _path;

    public async Task LoadDataAsync()
    {
        var data = await FileHelper.ReadAllTextAsync(_path);

        Data = data;
        IsRunning = false;
        IsVisibleText = true;
    }

    public LegalNoticiesViewModel(string path)
    {
        _path = path;
        IsRunning = true;
        isVisibleText = false;
    }
}
