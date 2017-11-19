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
        private Prompt _currentPrompt;

        public SpeechSynthesisService(ILogger<SpeechSynthesisService> logger)
        {
            _logger = logger;

            _speechSynthesizer = new SpeechSynthesizer();
            _speechSynthesizer.SpeakCompleted += OnSpeakCompleted;
            _currentPrompt = null;
        }

        public void Speak(string textToSpeak)
        {
            _currentPrompt = _speechSynthesizer.SpeakAsync(textToSpeak);
        }

        public void Stop()
        {
            if (_currentPrompt != null)
            {
                _speechSynthesizer.SpeakAsyncCancel(_currentPrompt);
            }
        }

        private void OnSpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            _currentPrompt = null;
        }
    }
}
