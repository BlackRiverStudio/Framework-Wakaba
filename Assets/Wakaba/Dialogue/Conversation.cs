using UnityEngine;
using NonSerialized = System.NonSerializedAttribute;
using Serializable = System.SerializableAttribute;
namespace Wakaba.Dialogue
{
    /// <summary>This is a ScriptableObject that contains information about a specific Conversation accessible within the game.</summary>
    [CreateAssetMenu(menuName = "Wakaba/Dialogue/Conversation", fileName = "NewConversation")]
    public class Conversation : ScriptableObject
    {
        /// <summary>Information regarding the actions avaliable within the dialogue line. Alows for a dynamic system with branching options for conversations.</summary>
        [Serializable] public struct ActionInfo
        {
            [Tooltip("Actions avaliable for each button to lead into the next dialogue line.\nNext and Branch cannot be used in conjunction. Instead requires two or more Branches, or Bye.")]
            public DialogueActions action;

            [Tooltip("Display text for the button in question.")]
            public string label;

            [Tooltip("Only used for JumpTo.")]
            public int nextLine;

            public bool isBranch;
        }

        /// <summary>Information for a single line of dialogue. Includes the Speaker, their words, and possible actions from there.</summary>
        [Serializable] public class DialogueLine
        {
            [Tooltip("Currently speaking NPC or PC.")]
            public Speaker speaker;

            [TextArea(1, 8), Tooltip("Currently being spoken text.")]
            public string dialogue;

            [Tooltip("Avaliable actions for the player to select. Requires at least 1 action.")]
            public ActionInfo[] actions;
        }

        [SerializeField, Tooltip("An array of DialogueLines within the specific Conversation.")]
        private DialogueLine[] lines;
        public DialogueLine[] GetLines => lines; //{ get; private set; }
        
        [NonSerialized] public int index = 0;
    }

    /// <summary>
    /// Types of dialogue actions avaliable.
    /// </summary>
    public enum DialogueActions 
    {
        /// <summary>
        /// following DialogueLine in array.
        /// </summary>
        Next,
        /// <summary>
        /// specific DialogueLine in array chosen within the Inspector.
        /// </summary>
        Branch,
        /// <summary>
        /// ends Conversation.
        /// </summary>
        Bye
    }
}