using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformShaker : MonoBehaviour
{
    public GameObject targetObject;
    public float shakeDuration = 0.3f;
    public float shakeAmount = 0.05f;
    public float fallDistance = 2f;
    public float fallDuration = 0.3f;

    private Vector3 originalPosition;
    private bool isActivated = false;

    private void Start()
    {
        if (targetObject != null)
        {
            originalPosition = targetObject.transform.localPosition;
        }
        else
        {
            Debug.LogError("PlatformShaker: No targetObject assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            isActivated = true;
            StartCoroutine(ShakeFallDisappear());
        }
    }

    private IEnumerator ShakeFallDisappear()
    {
        // Shake
        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            Vector3 offset = Random.insideUnitSphere * shakeAmount;
            targetObject.transform.localPosition = originalPosition + new Vector3(offset.x, offset.y, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        targetObject.transform.position = originalPosition;

        //fall
        elapsed = 0f;
        Vector3 startFall = originalPosition;
        Vector3 endFall = originalPosition + Vector3.down * fallDistance;
        
        while (elapsed < fallDuration)
        {
            targetObject.transform.position = Vector3.Lerp(startFall, endFall, elapsed / fallDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        targetObject.transform.position = endFall;

        // Disappear
        targetObject.SetActive(false);
    }
}
