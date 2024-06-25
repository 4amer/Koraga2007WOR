using DialogueSystem;
using Zenject;

namespace UI
{
    public class DialogueModel
    {
        private DialogueManager _dialogueManager;
        /*test*/private DialogueViewModel _viewModel;

        [Inject]
        public void Construct(DialogueManager dm, /* test */ DialogueViewModel dvm)
        {
            _dialogueManager = dm;
            /*test*/ _viewModel = dvm; _dialogueManager.DialogueStart += StartDialogue;
        }

        public Sentence NextSentence()
        {
            return _dialogueManager.NextSetence();
        }

        //delete after testing
        public void StartDialogue()
        {
            _viewModel.NextSentence();
        }
    }
}