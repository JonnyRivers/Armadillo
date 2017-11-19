using System;

namespace SayIt.ApplicationServices
{
    public interface ISpeechSynthesisService
    {
        event Action SpeakCompleted;

        void Speak(string text);
        void Stop();
    }
}
