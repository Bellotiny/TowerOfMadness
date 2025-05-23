using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;

    public List<DialogueLine> lines = new List<DialogueLine>();
    private int currentLineIndex = 0;
    private bool isDialogueActive = false;

    void Update()
    {
        if (isDialogueActive && Input.GetMouseButtonDown(0)) // Left click
        {
            ShowNextLine();
        }
    }

    public void StartDialogue(List<DialogueLine> newLines)
    {
        Time.timeScale = 0f;
        lines = newLines;
        currentLineIndex = 0;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        ShowCurrentLine();
    }

    private void ShowCurrentLine()
    {
        DialogueLine line = lines[currentLineIndex];
        speakerNameText.text = line.speaker;
        dialogueText.text = line.text;
    }

    private void ShowNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < lines.Count)
        {
            ShowCurrentLine();
        }
        else
        {
            EndDialogue();
        }
    }

    public void LoadDialogueFromFile(string fileName)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Dialogue/" + fileName);
        if (jsonFile == null)
        {
            Debug.LogError($"Dialogue file {fileName} not found!");
            return;
        }

        DialogueContainer container = JsonUtility.FromJson<DialogueContainer>(jsonFile.text);
        StartDialogue(container.lines);
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        Time.timeScale = 1f;
        isDialogueActive = false;
    }
}
