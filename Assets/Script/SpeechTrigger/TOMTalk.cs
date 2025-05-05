using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TOMTalk : MonoBehaviour
{
  public TextMeshPro textObject;
    public float showTime = 2f;

    void Start()
    {
        textObject.gameObject.SetActive(false); // Hide at start
    }

    public void Talk(string message)
    {
        textObject.text = message;
        textObject.gameObject.SetActive(true);
        CancelInvoke(); // Prevent overlap
        Invoke("HideSpeech", showTime);
    }

    void HideSpeech()
    {
        textObject.gameObject.SetActive(false);
    }
}
