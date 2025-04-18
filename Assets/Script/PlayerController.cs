using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement movement;
    private Rigidbody rb;
    public Collider[] attackColliders;
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<CharacterMovement>();
        rb = GetComponentInParent<Rigidbody>();
        foreach( Collider attackCollider in attackColliders)
        {
            attackCollider.enabled = false; // Disable collider at start
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("CharacterSpeed", rb.velocity.magnitude);
        animator.SetBool("IsGrounded", movement.IsGrounded);

        if(Input.GetButtonUp("Fire1")){
            //animator.SetTrigger("doRoll");
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
