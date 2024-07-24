using MobileInput;
using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Zenject;


namespace CutsceneSystem
{
    public class CutsceneManager : MonoBehaviour, ICutsceneManagerActions, ICutsceneManager
    {
        [SerializeField] private PlayableDirector _playableDirector = null;

        private IViewManager _viewManager = null;

        public event Action CutsceneStarted;
        public event Action CutsceneEnded;

        private List<CutsceneTrigger> _triggersWherePlayerStay = new List<CutsceneTrigger>();

        private bool _cutsceneStarted = false;

        [Inject]
        public void Consrtuct(CutsceneTrigger[] triggers, IScreenButton[] buttons, IViewManager viewManager)
        {
            _playableDirector.stopped += EndCutscene;
            _viewManager = viewManager;
            foreach (ScreenButton button in buttons)
            {
                if (button.ButtonBehaviour == ButtonBehaviour.Action)
                {
                    button.Button.onClick.AddListener(EtheractButtonClick);
                    break;
                }
            }
            foreach (CutsceneTrigger trigger in triggers)
            {
                trigger.CutsceneStarted += StartCutscene;
                trigger.PlayerEntered += AddTriggerToList;
                trigger.PlayerExited += RemoveTriggerToList;
            }
        }

        private void AddTriggerToList(CutsceneTrigger trigger)
        {
            _triggersWherePlayerStay.Add(trigger);
            Debug.Log("asdasdasdadasdasdasdasdasd");
        }
        
        private void RemoveTriggerToList(CutsceneTrigger trigger)
        {
            _triggersWherePlayerStay.Remove(trigger);
        }

        private void StartCutscene(TimelineAsset asset)
        {
            
            _cutsceneStarted = true;
            _playableDirector.playableAsset = asset;
            _playableDirector.Play();
            CutsceneStarted?.Invoke();
        }

        private void EndCutscene(PlayableDirector director)
        {
            _cutsceneStarted = false;
            _playableDirector.playableAsset = null;
            CutsceneEnded?.Invoke();
        }

        public void EtheractButtonClick()
        {
            Debug.Log($"{_triggersWherePlayerStay.Count == 0} : {_cutsceneStarted}");
            if (_triggersWherePlayerStay.Count == 0 || _cutsceneStarted) return;

            StartCutscene(_triggersWherePlayerStay[0].TimelineAsset);
        }

        public void PauseCutscene()
        {
            _playableDirector?.Pause();
        }

        public void ResumeCutscene()
        {
            if (_playableDirector.playableAsset == null) return; 
            _playableDirector?.Play();
        }
    }

    public interface ICutsceneManager
    {
        public void PauseCutscene();
        public void ResumeCutscene();
    }

    public interface ICutsceneManagerActions
    {
        public event Action CutsceneStarted;
        public event Action CutsceneEnded;
    }
}