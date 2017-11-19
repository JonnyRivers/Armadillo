using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace SayIt.ApplicationServices
{
    public class SpeechSynthesisService : ISpeechSynthesisService
    {
        private ILogger<SpeechSynthesisService> _logger;
        private SpeechSynthesizer _speechSynthesizer;

        public SpeechSynthesisService(ILogger<SpeechSynthesisService> logger)
        {
            _logger = logger;

            _speechSynthesizer = new SpeechSynthesizer();
        }

        public void Speak(string textToSpeak)
        {
            _speechSynthesizer.Speak(textToSpeak);
        }
    }
}
