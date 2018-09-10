using System;
namespace XAMCHALENGES.Control
{
    public class AudioPlayer
    {
        public AudioPlayer()
        {
        }
    }

    public interface IAudioPlayer
    {
        void PlayAudio(string FilePath);
        void PauseOrResumeAudio();
        void StopAudio();
    }
}
