using System;
using System.Collections;
using UnityEngine;

public class PlatformShaker : MonoBehaviour
{
    public GameObject targetObject;
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.1f;
    public float fallDistance = 2f;
    public float fallDuration = 0.5f;
    public float disappearDelay = 0.5f;

    private Vector3 originalPosition;
    private bool isActivated = false;

    public Action OnShakingComplete;

    void Start()
    {
        if (targetObject != null)
        {
            originalPosition = targetObject.transform.localPosition;
        }
    }

    public void TriggerShake()
    {
        if (!isActivated)
        {
            isActivated = true;
            StartCoroutine(ShakeAndDisappear());
        }
    }

    private IEnumerator ShakeAndDisappear()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector3 offset = UnityEngine.Random.insideUnitSphere * shakeAmount;
            targetObject.transform.localPosition = originalPosition + new Vector3(offset.x, offset.y, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        targetObject.transform.localPosition = originalPosition;

        elapsed = 0f;
        Vector3 startFall = originalPosition;
        Vector3 endFall = originalPosition + new Vector3(0, -fallDistance, 0);

        while (elapsed < fallDuration)
        {
            targetObject.transform.localPosition = Vector3.Lerp(startFall, endFall, elapsed / fallDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        targetObject.transform.localPosition = endFall;

        yield return new WaitForSeconds(disappearDelay);
        targetObject.SetActive(false);

        OnShakingComplete?.Invoke();
    }
}
