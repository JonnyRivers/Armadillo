using Armadillo.Commands;
using Armadillo.ViewModels;
using SayIt.ApplicationServices;
using System.Windows.Input;

namespace SayIt.ViewModels
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private const string DefaultTextToSpeak = "Hello, World!";

        private ISpeechSynthesisService _speechSynthesisService;

        private string _textToSpeak;
        private bool _isSpeaking;

        public MainWindowViewModel(ISpeechSynthesisService speechSynthesisService)
        {
            _speechSynthesisService = speechSynthesisService;
            _speechSynthesisService.SpeakCompleted += OnSpeakCompleted;

            _textToSpeak = DefaultTextToSpeak;
            _isSpeaking = false;
        }

        private void OnSpeakCompleted()
        {
            _isSpeaking = false;
            CommandManager.InvalidateRequerySuggested();
        }

        public ICommand SpeakCommand => new RelayCommand(SpeakExecute, SpeakCanExecute);
        public ICommand StopCommand => new RelayCommand(StopExecute, StopCanExecute);

        public string TextToSpeak
        {
            get
            {
                return _textToSpeak;
            }
            set
            {
                if (_textToSpeak != value)
                {
                    _textToSpeak = value;
                    OnPropertyChanged();
                }
            }
        }

        private void SpeakExecute(object obj)
        {
            _speechSynthesisService.Speak(TextToSpeak);
            _isSpeaking = true;
        }

        private bool SpeakCanExecute(object obj)
        {
            return !_isSpeaking;
        }

        private void StopExecute(object obj)
        {
            _speechSynthesisService.Stop();
            _isSpeaking = false;
        }

        private bool StopCanExecute(object obj)
        {
            return _isSpeaking;
        }
    }
}
