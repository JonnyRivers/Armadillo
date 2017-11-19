using System.Windows.Input;

namespace SayIt.ViewModels
{
    public interface IMainWindowViewModel
    {
        string TextToSpeak { get; set; }
        ICommand SpeakCommand { get; }
        ICommand StopCommand { get; }
    }
}
