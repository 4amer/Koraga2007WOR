using DialogueSystem;
using Zenject;

namespace UI
{
    public class DialogueModel
    {
        private IDialogueManager _dialogueManager;

        [Inject]
        public void Construct(IDialogueManager dm)
        {
            _dialogueManager = dm;
        }

        public Sentence NextSentence()
        {
            return _dialogueManager.NextSetence();
        }
    }
}