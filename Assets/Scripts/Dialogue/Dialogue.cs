using System;
using DialogueSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "StandartDialogue", menuName = "koragaStuff/Dualogues/StandartDialogue", order = 1)]
    public class Dialogue : ScriptableObject
    {
        public Dialogue nextDialogueAfterEnd = null;

        public string characterName = string.Empty;
        public string[] conversation = null;
        public DialogueAnswer[] answers = null;

        public UnityEvent eventAfterDialogue = null;
    }

    public class DialogueAnswer
    {
        public Dialogue dialogueContinue = null;
        public string answerText = string.Empty;
        public UnityEvent eventAfterAnswer = null;
    }
}