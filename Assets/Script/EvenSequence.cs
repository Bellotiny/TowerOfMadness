using System.Collections;
using UnityEngine;

public class EventSequence : MonoBehaviour
{
    [Header("Step 1: Platform Shaking (optional)")]
    public PlatformShaker platformShaker;

    [Header("Step 2: Dialogue & Animation (optional)")]
    public TOMTalk talker;
    public string dialogueMessage;
    public Animator spikeDoorAnimator;
    public string animationTrigger;

    [Header("Step 3: Teleport (optional)")]
    public GameObject teleportEffectPrefab;
    public Transform teleportDestination;

    [Header("Trigger Settings")]
    public string targetTag = "Player";
    public float waitAfterDialogue = 2f;
    public float waitBeforeTeleport = 2f;

    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated || !other.CompareTag(targetTag)) return;

        isActivated = true;

        StartCoroutine(RunSequence(other.gameObject));
    }

    private IEnumerator RunSequence(GameObject player)
    {
        // Step 1: Shake platform if assigned
        if (platformShaker != null)
        {
            bool shakeDone = false;
            platformShaker.OnShakingComplete = () => shakeDone = true;
            platformShaker.TriggerShake(); // Call a public method to start shake
            yield return new WaitUntil(() => shakeDone);
        }

        // Step 2: Dialogue and animation
        if (talker != null && !string.IsNullOrEmpty(dialogueMessage))
        {
            talker.Talk(dialogueMessage);
        }

        CharacterMovement movement = player.GetComponent<CharacterMovement>();
        if (movement != null)
            movement.enabled = false;

        if (spikeDoorAnimator != null && !string.IsNullOrEmpty(animationTrigger))
        {
            spikeDoorAnimator.SetTrigger(animationTrigger);
        }

        yield return new WaitForSeconds(waitAfterDialogue);

        // Step 3: Teleport with particle
        if (teleportEffectPrefab != null && player != null)
        {
            GameObject effectInstance = Instantiate(
                teleportEffectPrefab,
                player.transform.position,
                Quaternion.Euler(-90f, 0f, 0f)
            );
            // var ps = teleportEffectPrefab.GetComponent<ParticleSystem>();
            // if (ps != null)
            //     ps.Play();

            yield return new WaitForSeconds(waitBeforeTeleport);

            // Teleport the player
            if (teleportDestination != null)
            {
                Debug.Log(teleportDestination.position);
                player.transform.position = teleportDestination.position;
            }

            // Destroy the particle effect after 2 seconds
            yield return new WaitForSeconds(2f);
            effectInstance.SetActive(false);

            //yield return new WaitForSeconds(2);

        }
        
        if (movement != null)
            movement.enabled = true;

      
        
        //Destroy(teleportEffectPrefab,2f);
    }
}
