using UnityEngine;

namespace UnidosJam
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource[] _audioSources;
        public static SoundManager Instance { get; private set; }

        private void Awake()
        {
            SingletonObject();
            _audioSources = GetComponentsInChildren<AudioSource>();
        }

        private void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void PlayAssistantMessageSoundEffect()
        {
            if (!_audioSources[0].isPlaying)
            {
                _audioSources[0].Play();
                _audioSources[0].mute = true;
            }
        }

        public void PlayButtonClickSoundEffect()
        {
            if (!_audioSources[1].isPlaying)
                _audioSources[1].Play();
        }

        public void PlayYawnSoundEffect()
        {
            if (!_audioSources[2].isPlaying)
                _audioSources[2].Play();
        }

        public void PlayKeyboardTypingSoundEffect()
        {
            if (!_audioSources[3].isPlaying)
                _audioSources[3].Play();
        }
        
        public void StopKeyboardTypingSoundEffect()
        {
            if (_audioSources[3].isPlaying)
                _audioSources[3].Stop();
        }

        public void PlayMailClickSoundEffect()
        {
            if (!_audioSources[4].isPlaying)
                _audioSources[4].Play();
        }

        public void PlayNoButtonPressedSoundEffect()
        {
            if (!_audioSources[5].isPlaying)
                _audioSources[5].Play();
        }

        public void PlayThoughtfulSoundEffect()
        {
            if (!_audioSources[6].isPlaying)
                _audioSources[6].Play();
        }

        public void PlayYesButtonSoundEffect()
        {
            if (!_audioSources[7].isPlaying)
                _audioSources[7].Play();
        }
    }
}