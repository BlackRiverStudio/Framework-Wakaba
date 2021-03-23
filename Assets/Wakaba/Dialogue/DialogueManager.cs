using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Wakaba.Dialogue
{
    /// <summary>
    /// Manages the UI interface of the Dialogue System, and functions used in it's operation.
    /// Multiple Conversation objects can and should exist, but they are not able to be attached as a compnent.</summary>
    public class DialogueManager : MonoBehaviour
    {
        [Tooltip("The static instance of the DialogueManager. Named 'v' to represent a downward pointing arrow.")]
        private static DialogueManager v; // Steph, no. That's not what it stands for.

        [Header("UI")]
        [SerializeField, Tooltip("Prefab UI Panel, with DialogueManager attached as a component on parent Canvas.")]
        private GameObject dialoguePanel;
        [SerializeField, Tooltip("UI Text element.")]
        private Text speakerName, dialogue;
        [SerializeField, Tooltip("UI Image element.")]
        private Image speakerSprite;
        [SerializeField, Tooltip("Instaniatable prefab for buttons.")]
        private GameObject buttonPrefab;
        [SerializeField, Tooltip("Parent object for buttonPrefab to be instanciated into.")]
        private Transform buttonParent;
        [Tooltip("")] private List<Button> buttons = new List<Button>();

        private Conversation currentConvo;

        private void Awake()
        {
            if (v == null) v = this;
            else if (v != this) throw new InvalidOperationException("DialogueManager instance doen't exist.");
        }

        /// <summary>Initiates a Conversation. Requires a filled Conversation ScriptableGameobject.</summary>
        /// <param name="_convo">Conversation being referenced.</param>
        public static void StartConversation(Conversation _convo)
        {
            v.dialoguePanel.SetActive(true);
            v.currentConvo = _convo;
            v.currentConvo.index = 0;
            v.speakerName.text = "";
            v.speakerSprite.sprite = null;
            v.dialogue.text = "";
            foreach (Button butt in v.buttons) butt.gameObject.SetActive(false);
            v.UpdateDisplay();
        }

        /// <summary>!going to rewrite this to make it more dynamic. Worldspace canvas and animations in mind. Stuff like that.</summary>
        private void EndConversation() => dialoguePanel.SetActive(false);

        /// <summary>Refreshes UI components as required for current DialogueLine</summary>
        private void UpdateDisplay()
        {
            ResetButtons();
            
            Conversation.DialogueLine line = currentConvo.GetLines[currentConvo.index];
            
            speakerName.text = line.speaker.GetName;
            speakerSprite.sprite = line.speaker.GetSprite;
            dialogue.text = line.dialogue;

            foreach (Conversation.ActionInfo action in line.actions)
            {
                Button butt = null;
                butt = Instantiate(buttonPrefab, buttonParent).GetComponent<Button>();
                butt.gameObject.SetActive(true);
                int target = 0;
                switch (action.action)
                {
                    case DialogueActions.Next:
                        target = currentConvo.index + 1;
                        butt.onClick.AddListener(() => JumpTo(target));
                        break;

                    case DialogueActions.Branch:
                        target = action.nextLine;
                        butt.onClick.AddListener(() => JumpTo(target));
                        break;

                    case DialogueActions.Bye:
                        butt.onClick.AddListener(() => EndConversation());
                        break;
                }
                buttons.Add(butt);
                butt.GetComponentInChildren<Text>().text = action.label;
            }
        }
        
        /// <summary>Changes Conversation index, and updates the display accordingly.</summary>
        /// <param name="_index">The destination DialogueLine.</param>
        public void JumpTo(int _index)
        {
            currentConvo.index = _index;
            UpdateDisplay();
        }

        /// <summary>What it says on the tin.</summary>
        private void ResetButtons()
        {
            if (buttons.Count > 0)
            {
                foreach (Button butt in buttons) Destroy(butt.gameObject);
                buttons.Clear();
            }
        }
    }
}