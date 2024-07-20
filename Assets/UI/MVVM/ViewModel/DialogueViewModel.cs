using DialogueSystem;
using System.Threading.Tasks;
using Zenject;

namespace UI
{
    public class DialogueViewModel
    {
        private DialogueView dialogueView;
        private DialogueModel dialogueModel;

        [Inject]
        public void Contruct(DialogueModel model, DialogueView view)
        {
            dialogueView = view;
            dialogueView.NextSentenceClicked += NextSentence;

            dialogueModel = model;
        }

        public void NextSentence()
        {
            Sentence sentence = dialogueModel.NextSentence();
            if (sentence == null) return;
            dialogueView.CharacterName = sentence.characterName;
            SmoothShowText(sentence.timeCharacterAppear,sentence.sentencesText,dialogueView);
        }

        private async void SmoothShowText(float waitTime, string sentence, DialogueView view)
        {
            string animateSentence = string.Empty;
            foreach(char character in sentence)
            {
                animateSentence += character;
                view.ConversationText = animateSentence;
                await Task.Delay((int) waitTime * 1000);
            }
        }
    }
}