using Microsoft.Extensions.Logging;
using System;
using System.Speech.Synthesis;

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

        public event Action SpeakCompleted = delegate { };

        public void Speak(string textToSpeak)
        {
            _logger.LogInformation($"Speak({textToSpeak})");

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
            SpeakCompleted();
            _currentPrompt = null;
        }
    }
}
