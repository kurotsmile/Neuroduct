using UnityEngine;

namespace View.Control
{
    /// <summary>
    /// The main controller for the game's audio. Handles SFX along with looping music.
    /// </summary>
    public class GameAudio : MonoBehaviour
    {
        public Carrot.Carrot Carrot;
        
        private const float MusicVolume = 0.2f;
        
        public AudioClip[] SfxClips;

        private int _musicVolumeTweenId;
        private bool _musicEnabled = true;
        public bool MusicEnabled
        {
            get { return _musicEnabled; }
            set {
                if (_musicEnabled != value) {
                    LeanTween.cancel(_musicVolumeTweenId);
                }
                
                _musicEnabled = value;
            }
        }

        private bool _sfxEnabled = true;
        public bool SfxEnabled
        {
            get { return _sfxEnabled; }
            set {
                _sfxEnabled = value;
            }
        }

        /// <summary>
        /// Plays the given sound clip with the specified parameters.
        /// </summary>
        public void Play(GameClip clip, float delay = 0f, float volume = 1f, float startTime = 0f)
        {
            var audioClip = SfxClips[(uint) clip];
            if(this.Carrot.get_status_sound()) LeanAudio.play(audioClip, volume, delay, time: startTime);
        }

    }

    /// <summary>
    /// A one-to-one map of all sound clips
    /// </summary>
    public enum GameClip
    {
        GameStart,
        WinBoard,
        NodeEnter,
        NodeLeave,
        MovePushHigh,
        MovePullHigh,
        MovePullMid,
        MovePushMid,
        MovePullLow,
        MovePushLow,
        ArcMoveHigh,
        NodeRotate90,
        InvalidRotate,
        MenuSelect,
        GameEnd,
        LevelEnable,
        ArcMoveMid,
        ArcMoveLow
    }

    /// <summary>
    /// A one-to-one map of all music clips
    /// </summary>
    public enum MusicClip
    {
        Ambient01,
        Ambient02
    }
}
