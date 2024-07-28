using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SoundSystem
{
    public class SoundManager : MonoBehaviour, ISoundManager
    {
        [SerializeField] private AudioSource _musicAudioSource = null;
        [SerializeField] private AudioSource _soundAudioSource = null;

        [SerializeField] private ClipWithName[] _musicsAudioClip = new ClipWithName[0];
        [SerializeField] private ClipWithName[] _soundsAudioClip = new ClipWithName[0];

        private Dictionary<EnumSounds, AudioClip> _soundsAudioClipStore = new Dictionary<EnumSounds, AudioClip>();
        private Dictionary<EnumSounds, AudioClip> _musicsAudioClipStore = new Dictionary<EnumSounds, AudioClip>();

        private void Awake()
        {
            _soundsAudioClipStore = _soundsAudioClip.ToDictionary(item => item.name, 
                                                                  item => item.clip);
            _musicsAudioClipStore = _musicsAudioClip.ToDictionary(item => item.name, 
                                                                  item => item.clip);
        }

        public void PlayLoopMusic(EnumSounds music)
        {
            AudioClip clip = _musicsAudioClipStore[music];
            _musicAudioSource.loop = true;
            _musicAudioSource.clip = clip;
            _musicAudioSource.Play();
        }

        public void PlaySound(EnumSounds sound)
        {
            AudioClip clip = _soundsAudioClipStore[sound];
            _soundAudioSource.PlayOneShot(clip);
        }

        public void MusicVolume(float volume)
        {
            _musicAudioSource.volume = volume; 
        }
        public void SoundVolume(float volume)
        {
            _soundAudioSource.volume = volume;
        }
    }

    public interface ISoundManager
    {
        public void PlayLoopMusic(EnumSounds music);
        public void PlaySound(EnumSounds sound);
        public void SoundVolume(float volume);
        public void MusicVolume(float volume);
    }

    [Serializable]
    public class ClipWithName
    {
        public EnumSounds name;
        public AudioClip clip;
    }
}