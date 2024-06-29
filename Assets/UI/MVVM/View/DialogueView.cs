using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class DialogueView : BaseView
    {
        [SerializeField] private TextMeshProUGUI _characterName = null;
        [SerializeField] private TextMeshProUGUI _conversationText = null;

        public event Action NextSentenceClicked;

        private void OnEnable()
        {
            NextSentenceClicked?.Invoke();
        }

        public void ButtonNextSentenceClicked(InputAction.CallbackContext callback)
        {
            if(callback.control.magnitude == 0)
            {
                NextSentenceClicked?.Invoke();
            }
        }

        public string CharacterName
        {
            set
            {
                _characterName.text = value;
            }
        }

        public string ConversationText
        {
            set
            {
                _conversationText.text = value;
            }
        }
    }
}