using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    public string dialogueFileName = "Dialogue/intro_dialogue";
    public DialogueManager dialogueManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(dialogueFileName);

            if (jsonFile != null)
            {
                DialogueContainer container = JsonUtility.FromJson<DialogueContainer>(jsonFile.text);
                dialogueManager.StartDialogue(container.lines);
            }
            else
            {
                Debug.LogError("Dialogue file not found: " + dialogueFileName);
            }
        }
    }
}
