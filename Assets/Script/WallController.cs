using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public float moveDistance = 3f;      
    public float moveDuration = 1f;       

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void OpenAndCloseWall(float waitTime)
    {
        StartCoroutine(MoveUpAndDown(waitTime));
    }

    IEnumerator MoveUpAndDown(float waitTime)
    {
        Vector3 targetPosition = originalPosition + Vector3.up * moveDistance;

        yield return MoveToPosition(targetPosition);
        yield return new WaitForSeconds(waitTime);

        
        yield return MoveToPosition(originalPosition);
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        Vector3 start = transform.position;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(start, target, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}
