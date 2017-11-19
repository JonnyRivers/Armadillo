using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
