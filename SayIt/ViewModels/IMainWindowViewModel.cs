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
        ICommand SaySomethingCommand { get; }
    }
}
