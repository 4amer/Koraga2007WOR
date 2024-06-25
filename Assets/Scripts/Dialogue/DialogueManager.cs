using DialogueSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace DialogueSystem
{
    public class DialogueManager
    {
        private Dialogue _currentDialogue;
        private Queue<Sentence> _sentences;


        public event Action DialogueEnd;
        public event Action DialogueStart;
        public event Action<DialogueAnswer[]> HasAnswers;

        [Inject]
        public void Construct(DialogueTrigger[] triggers)
        {
            foreach (DialogueTrigger trigger in triggers)
            {
                trigger.DialogueStarted += StartDialogue;
            }
        }

        private void StartDialogue(Dialogue dialogue)
        {
            _currentDialogue = dialogue;
            _sentences = new Queue<Sentence>(_currentDialogue.sentences);
            DialogueStart?.Invoke();
        }

        private void NextDialogue()
        {
            if (_currentDialogue.nextDialogueAfterEnd == null)
            {
                DialogueEnd?.Invoke();
                _currentDialogue = null;
                return;
            }
            _currentDialogue = _currentDialogue.nextDialogueAfterEnd;
            _sentences.Clear();
            _sentences = new Queue<Sentence>(_currentDialogue.sentences);
            if (_currentDialogue.eventAfterDialogue == null)
            {
                return;
            }
            _currentDialogue.eventAfterDialogue.Invoke();
        }

        public Sentence NextSetence()
        {
            if (_sentences == null || _sentences.Count == 0)
            {
                NextDialogue();
            }
            if (_currentDialogue == null) return null;
            return _sentences.Dequeue();
        }
    }
}