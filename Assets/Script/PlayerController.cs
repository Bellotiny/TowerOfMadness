using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement movement;
    private Rigidbody rb;
    [SerializeField] private float fallThresholdY = -10f;
    private PlayerHealth health;
    public Collider[] attackColliders;
    private AudioSource audioSource;
    public AudioClip footstepSound;
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody>();
        health = GetComponent<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
        foreach (Collider attackCollider in attackColliders)
        {
            attackCollider.enabled = false; // Disable collider at start
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("CharacterSpeed", rb.velocity.magnitude);
        animator.SetBool("IsGrounded", movement.IsGrounded);

        if (Input.GetButtonUp("Fire1"))
        {
            //animator.SetTrigger("doRoll");
        }

        if (transform.position.y < fallThresholdY)
        {
            if (health != null)
            {
                Debug.Log("Player has fallen!!!!");
                health.Die();
            }
        }
        if (movement.IsGrounded && rb.velocity.magnitude > 0.1f)
        {
            if (!audioSource.isPlaying)
                {
                    Debug.Log("walking sound");
                    audioSource.PlayOneShot(footstepSound);
                }
        }
    }
    public void EnableHitbox()
    {
        foreach( Collider attackCollider in attackColliders)
        {
            attackCollider.enabled = true;
        }
    }
    public void DisableHitbox()
    {
        foreach( Collider attackCollider in attackColliders)
        {
            attackCollider.enabled = false;
        }
    }

}
