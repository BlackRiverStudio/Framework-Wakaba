using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wakaba.Dialogue;
public class Tester : MonoBehaviour
{
    public Conversation convo;
    public void Start()
    {
        DialogueManager.StartConversation(convo);
    }
}
