using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayIt.ApplicationServices
{
    public interface ISpeechSynthesisService
    {
        void Speak(string text);
    }
}
