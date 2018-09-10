using System;
using System.IO;
using System.Runtime.CompilerServices;
using AVFoundation;
using Foundation;
using XAM_CHALENGES.iOS.Services;
using XAMCHALENGES.Control;

[assembly: Xamarin.Forms.Dependency(typeof(AudioPlayer_IOS))]
namespace XAM_CHALENGES.iOS.Services
{
    public class AudioPlayer_IOS:IAudioPlayer
    {
        AVAudioPlayer player;
    

        public void PauseOrResumeAudio()
        {
            if (player.Playing)
            {
                player?.Pause();
            }
            else
            {
                player?.Play();
            }
        }

        public void PlayAudio(string FilePath)
        {
            string filepaht = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "20-04 Nenjil Mamazhai __ isaimini.net.mp3");
            NSUrl url;
            var audioSession = AVAudioSession.SharedInstance();
            var err = audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
            err = audioSession.SetActive(true);
            url = NSUrl.FromFilename(filepaht);
               player = new AVAudioPlayer(url, ".WAV", out err);
            if (player.Playing) { player.Stop(); }
            player.Volume = 0.6f;
            player.NumberOfLoops = 0;
            player.Play();

        }

        public void StopAudio()
        {
            player?.Stop();
            player = null;
        }
    }
}
