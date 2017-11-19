using Armadillo.Commands;
using SayIt.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SayIt.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private ISpeechSynthesisService _speechSynthesisService;

        public MainWindowViewModel(ISpeechSynthesisService speechSynthesisService)
        {
            _speechSynthesisService = speechSynthesisService;
        }

        public ICommand SaySomethingCommand => new RelayCommand(SaySomethingExecute);

        private void SaySomethingExecute(object obj)
        {
            _speechSynthesisService.Speak("Hello, world!");
        }
    }
}
