using System;
using System.Collections;
using System.Collections.Generic;
using Triggers;
using UnityEngine;
using Zenject;

namespace DialogueSystem
{
    public class DialogueTrigger : AbstractTrigger
    {
        [SerializeField] private Dialogue _dialogue = null;

        public event Action<Dialogue> DialogueStarted;
        public event Action<DialogueTrigger> PlayerEntered;
        public event Action<DialogueTrigger> PlayerExited;

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
            DialogueStarted?.Invoke(_dialogue);
        }

        public Dialogue Dialogue 
        { 
            get 
            { 
                return _dialogue; 
            } 
        }
    }
}
