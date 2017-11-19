using Armadillo.Commands;
using Armadillo.ViewModels;
using SayIt.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SayIt.ViewModels
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private const string DefaultTextToSpeak = "Hello, World!";

        private ISpeechSynthesisService _speechSynthesisService;

        private string _textToSpeak;

        public MainWindowViewModel(ISpeechSynthesisService speechSynthesisService)
        {
            _speechSynthesisService = speechSynthesisService;

            _textToSpeak = DefaultTextToSpeak;
        }

        public ICommand SpeakCommand => new RelayCommand(SpeakExecute);
        public ICommand StopCommand => new RelayCommand(StopExecute);

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
        }

        private void StopExecute(object obj)
        {
            _speechSynthesisService.Stop();
        }
    }
}
