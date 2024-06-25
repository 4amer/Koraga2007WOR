using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private void OnCollisionEnter(Collision collision)
        {
            if (_triggerOnEnter)
            {
                StartDialogue();
            }

            if (collision.gameObject.tag == "Player")
            {
                isPlayerStay = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
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
            }
        }
    }
}
