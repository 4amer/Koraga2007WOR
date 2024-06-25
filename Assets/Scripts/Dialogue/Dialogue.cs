using System;
using UnityEngine;
using UnityEngine.Events;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "StandartDialogue", menuName = "koragaStuff/Dualogues/StandartDialogue", order = 1)]
    public class Dialogue : ScriptableObject
    {
        public Dialogue nextDialogueAfterEnd = null;

        public Sentence[] sentences = null;
        public DialogueAnswer[] answers = null;

        public UnityEvent eventAfterDialogue = null;
    }

    [Serializable]
    public class DialogueAnswer
    {
        public event Action<DialogueAnswer> onAnswer;

        public Dialogue dialogueContinue = null;
        public string answerText = string.Empty;
        public UnityEvent eventAfterAnswer = null;
    }

    [Serializable]
    public class Sentence
    {
        [Range(0f, 0.5f)] public float timeCharacterAppear = 0.05f;
        public string characterName;
        public string sentencesText;
    }
}