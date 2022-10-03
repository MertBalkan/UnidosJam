using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI copyRightText;
        [SerializeField] private Image soundOnImage;
        [SerializeField] private Image soundOffImage;

        private AudioSource _audioSource;

        private bool _isSoundPlaying = false;

        private void Awake()
        {
            _audioSource = GetComponentInChildren<AudioSource>();
        } 
        
        private void Start()
        {
            _audioSource.Play();

            UpdateButtonIcon();
            // AudioListener.pause = _isSoundPlaying;
        }

        private void Update()
        {
            UpdateVolume();
        }

        public void ChangeMusic(MusicScriptableObject musicSo)
        {
            _audioSource.clip = musicSo.musicSettings.musicClip;
            copyRightText.text = musicSo.musicSettings.copyrightText;
            
            if(!_audioSource.isPlaying)
                _audioSource.Play();
        }

        public void AdjustSoundOptions()
        {
            if (!_isSoundPlaying)
            {
                _isSoundPlaying = true;
                // AudioListener.pause = true;
                _audioSource.Stop();
            }
            else
            {
                _isSoundPlaying = false;
                // AudioListener.pause = false;
                _audioSource.Play();
            }

            SaveSound();
            UpdateButtonIcon();
        }

        private void UpdateButtonIcon()
        {
            if (!_isSoundPlaying)
            {
                soundOnImage.enabled = true;
                soundOffImage.enabled = false;
            }
            else
            {
                soundOnImage.enabled = false;
                soundOffImage.enabled = true;
            }
        }

        public void UpdateVolume()
        {
            _audioSource.volume = FindObjectOfType<MusicVolumeSlider>().MusicSlider.value;
        }

        private void LoadSound()
        {
            _isSoundPlaying = PlayerPrefs.GetInt("_isSoundPlaying") == 1;
        }

        private void SaveSound()
        {
            PlayerPrefs.SetInt("_isSoundPlaying", _isSoundPlaying ? 1 : 0);
        }
    }
}