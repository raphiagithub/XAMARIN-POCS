using System;
using Android.Media;
using XAM_CHALENGES.Droid.Dependencies;
using XAMCHALENGES.Control;

[assembly: Xamarin.Forms.Dependency(typeof(AudioPlayer_Droid))]
namespace XAM_CHALENGES.Droid.Dependencies
{
    public class AudioPlayer_Droid: IAudioPlayer
    {
        MediaPlayer mediaPlayer_Temp = new MediaPlayer();

        public void PauseOrResumeAudio()
        {
            if (mediaPlayer_Temp.IsPlaying)
                mediaPlayer_Temp.Pause();
            else
                mediaPlayer_Temp.Start();
        }

        public void PlayAudio(string FilePath)
        {
           
                mediaPlayer_Temp = null;
            
            MediaPlayer mediaPlayer = new MediaPlayer();

            mediaPlayer.SetVolume(0.8f, 0.8f);
            mediaPlayer.SetDataSource(FilePath);
            mediaPlayer.Prepare();
            mediaPlayer.Start();
            mediaPlayer_Temp = mediaPlayer;
            //mediaPlayer.Completion += OnCompleteMusic;
        }

        public void StopAudio()
        {
            if (mediaPlayer_Temp != null)
            {
                mediaPlayer_Temp.Stop();
                mediaPlayer_Temp.Release();
                mediaPlayer_Temp.Dispose();
                mediaPlayer_Temp = null;
            }
        }
    }
}
