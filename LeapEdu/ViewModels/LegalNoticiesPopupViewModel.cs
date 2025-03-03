using CommunityToolkit.Mvvm.ComponentModel;
using LeapEdu.Helpers;

namespace LeapEdu.ViewModels;

public partial class LegalNoticiesViewModel : ObservableObject
{
    private string _path;
    private bool _isRunning = true;
    private bool _isVisibleText = false;
    private string _data;

    public bool IsRunning
    {
        get => _isRunning;
        set => SetProperty(ref _isRunning, value);
    }

    public bool IsVisibleText
    {
        get => _isVisibleText;
        set => SetProperty(ref _isVisibleText, value);
    }

    public string Data
    {
        get => _data;
        set => SetProperty(ref _data, value);
    }

    public async Task LoadDataAsync()
    {
        var data = await FileHelper.ReadAllTextAsync(_path);

        Data = data;
        IsRunning = false;
        IsVisibleText = true;
    }

    public LegalNoticiesViewModel(string path) => _path = path;
}
