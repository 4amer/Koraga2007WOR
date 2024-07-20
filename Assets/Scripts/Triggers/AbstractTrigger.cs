using DialogueSystem;
using FSM.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Triggers
{
    public abstract class AbstractTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _triggerObject;
        [Space(10)]
        [SerializeField] private bool _triggerWhenActionButtonPressed = true;
        [SerializeField] private bool _triggerOnEnter = false;
        [SerializeField] private bool _offTriggerAhterAction = false;

        private bool isPlayerStay = false;

        public virtual void PlayerEnter() { }
        public virtual void PlayerExit() { }
        public virtual void DoEvent() { }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {
                isPlayerStay = true;
                if (_triggerOnEnter)
                {
                    StartEvent();
                }
                else
                {
                    PlayerEnter();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                isPlayerStay = false;
                PlayerExit();
            }
        }

        private void StartEvent()
        {
            if (isPlayerStay)
            {
                if (_offTriggerAhterAction)
                {
                    _triggerObject.active = false;
                
                }
                DoEvent();
            }
        }
    }
}