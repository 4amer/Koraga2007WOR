using DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using Triggers;
using UnityEngine;
using UnityEngine.Timeline;

namespace CutsceneSystem
{
    public class CutsceneTrigger : AbstractTrigger
    {
        [SerializeField] private TimelineAsset asset;

        public event Action<TimelineAsset> CutsceneStarted;
        public event Action<CutsceneTrigger> PlayerEntered;
        public event Action<CutsceneTrigger> PlayerExited;

        public override void PlayerEnter()
        {
            PlayerEntered?.Invoke(this);
           
        }

        public override void PlayerExit()
        {
            PlayerExited?.Invoke(this);
        }

        public override void DoEvent()
        {
            CutsceneStarted?.Invoke(asset);
        }

        public TimelineAsset TimelineAsset { get { return asset; } }
    }
}