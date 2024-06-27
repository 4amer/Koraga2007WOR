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

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {
                isPlayerStay = true;
                if (_triggerOnEnter)
                {

                    StartDialogue();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                isPlayerStay = false;
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
    }
}
