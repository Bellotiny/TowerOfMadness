using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Panel & Groups")]
    public GameObject dialoguePanel;
    public GameObject leftDialogueGroup;
    public GameObject rightDialogueGroup;
//------------------------------------------
    [Header("Speakers")]
    public string leftSpeakerName;
    public string rightSpeakerName;
//------------------------------------------
    [Header("TextMesh Objects")]
    public TextMeshProUGUI leftSpeakerNameText;
    public TextMeshProUGUI leftDialogueText;
    public Image leftSpeakerImage;
    public TextMeshProUGUI rightSpeakerNameText;
    public TextMeshProUGUI rightDialogueText;
    public Image rightSpeakerImage;
//------------------------------------------
    [Header("Speaker Images")]
    public Sprite leftSpeakerSprite;
    public Sprite rightSpeakerSprite;
    public List<DialogueLine> lines = new List<DialogueLine>();
    private int currentLineIndex = 0;
    private bool isDialogueActive = false;

    void Update()
    {
        if (isDialogueActive && Input.GetMouseButtonDown(0))
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

        if (line.speaker == rightSpeakerName)
        {
            leftDialogueGroup.SetActive(false);
            rightDialogueGroup.SetActive(true);

            rightSpeakerNameText.text = line.speaker;
            rightDialogueText.text = line.text;
            rightSpeakerImage.sprite = rightSpeakerSprite;
        }
        else if (line.speaker == leftSpeakerName)
        {
            rightDialogueGroup.SetActive(false);
            leftDialogueGroup.SetActive(true);

            leftSpeakerNameText.text = line.speaker;
            leftDialogueText.text = line.text;
            leftSpeakerImage.sprite = leftSpeakerSprite;
        }
        else
        {
            Debug.LogWarning($"Unknown speaker \"{line.speaker}\". Defaulting to left.");
            rightDialogueGroup.SetActive(false);
            leftDialogueGroup.SetActive(true);

            leftSpeakerNameText.text = line.speaker;
            leftDialogueText.text = line.text;
        }
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
