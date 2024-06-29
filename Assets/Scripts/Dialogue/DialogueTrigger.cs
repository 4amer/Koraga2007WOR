using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _triggerObject;

        [SerializeField] private bool _triggerWhenActionButtonPressed = true;
        [SerializeField] private bool _triggerOnEnter = false;
        [SerializeField] private bool _offTriggerAhterAction = false;

        [SerializeField] private Dialogue _dialogue = null;


        private bool isPlayerStay = false;

        public event Action<Dialogue> DialogueStarted;
        public event Action<DialogueTrigger> PlayerEntered;
        public event Action<DialogueTrigger> PlayerExited;


        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {
                isPlayerStay = true;
                if (_triggerOnEnter)
                {
                    StartDialogue();
                } 
                else
                {
                    PlayerEntered?.Invoke(this);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                isPlayerStay = false;
                PlayerExited?.Invoke(this);
            }
        }

        private void StartDialogue()
        {
            if (isPlayerStay)
            {
                if (_offTriggerAhterAction)
                {
                    _triggerObject.active = false;
                }
                DialogueStarted?.Invoke(_dialogue);
            }
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
