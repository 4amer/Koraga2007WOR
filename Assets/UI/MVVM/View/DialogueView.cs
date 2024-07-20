using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
    public class DialogueView : BaseView
    {
        [SerializeField] private TextMeshProUGUI _characterName = null;
        [SerializeField] private TextMeshProUGUI _conversationText = null;

        [SerializeField] private Button _nextSentenceButton;

        public event Action NextSentenceClicked;

        private void OnEnable()
        {
            NextSentenceClicked?.Invoke();
            _nextSentenceButton?.onClick.AddListener(ButtonNextSentenceClicked);
        }

        private void OnDisable()
        {
            _nextSentenceButton?.onClick.RemoveListener(ButtonNextSentenceClicked);
        }

        private void ButtonNextSentenceClicked()
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