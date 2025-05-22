using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public List<DialogueLine> dialogueToStart;
    private void OnTriggerEnter(Collider other)
    {
        dialogueManager.StartDialogue(dialogueToStart);
        gameObject.SetActive(false);
    }
}
