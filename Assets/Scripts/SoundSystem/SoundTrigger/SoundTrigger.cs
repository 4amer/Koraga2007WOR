using UnityEngine;
using Zenject;

namespace SoundSystem
{
    public class SoundTrigger : MonoBehaviour
    {
        [SerializeField] private PlaySoundSetting setting = PlaySoundSetting.None;
        [SerializeField] private EnumSounds sound = EnumSounds.None;

        [Inject] private ISoundManager _soundManager = null;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                switch (setting)
                {
                    case PlaySoundSetting.Music:
                        _soundManager.PlayLoopMusic(sound);
                        break;
                    case PlaySoundSetting.Sound:
                        _soundManager.PlaySound(sound);
                        break;
                }
            }
        }
    }

    public enum PlaySoundSetting
    {
        None = 0,
        Music = 1,
        Sound = 2,
    }
}