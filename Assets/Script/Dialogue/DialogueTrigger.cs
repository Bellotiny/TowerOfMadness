using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string dialogueFileName;
    private static HashSet<string> triggeredFiles = new HashSet<string>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggeredFiles.Contains(dialogueFileName))
            {
                return;
            }

            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
            if (dialogueManager != null)
            {
                triggeredFiles.Add(dialogueFileName);
                dialogueManager.LoadDialogueFromFile(dialogueFileName);
                gameObject.SetActive(false);
            }
        }
    }
    public static void ClearTriggeredFiles()
    {
        triggeredFiles.Clear();
    }
}
