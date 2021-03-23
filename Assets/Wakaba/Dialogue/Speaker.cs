using UnityEngine;
/// <summary>Module used to impliment a dynamic dialogue system.</summary>
namespace Wakaba.Dialogue
{
    /// <summary>A ScriptableObject that acts as a reference for a NPC or a PC that utilises the Dialogue system.</summary>
    [CreateAssetMenu(menuName = "Wakaba/Dialogue/Speaker", fileName = "NewSpeaker")]
    public class Speaker : ScriptableObject
    {
        [Tooltip("If this Speaker is known to the player, return true.")]
        public bool known;

        [SerializeField, Tooltip("The name of the NPC or PC speaking.")]
        private string speakerName;
        public string GetName
        {
            get
            {
                if (known) return speakerName;
                return "???";
            } 
        }
        
        [SerializeField, Tooltip("Speaker's face sprite that is displayed within the dialogue box.\n\nSprite sheet can be used to create multiple expressions.")]
        private Sprite speakerSprite;
        public Sprite GetSprite => speakerSprite;
    }
}