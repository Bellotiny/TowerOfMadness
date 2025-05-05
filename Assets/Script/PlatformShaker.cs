using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformShaker : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.1f;
    public float disappearDelay = 0.5f;

    private Vector3 originalPosition;
    private bool isActivated = false;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            isActivated = true;
            StartCoroutine(ShakeAndDisappear());
        }
    }

    IEnumerator ShakeAndDisappear()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeAmount;
            transform.localPosition = originalPosition + new Vector3(randomOffset.x, randomOffset.y, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
        yield return new WaitForSeconds(disappearDelay);

        gameObject.SetActive(false); // Or use Destroy(gameObject);
    }
}
