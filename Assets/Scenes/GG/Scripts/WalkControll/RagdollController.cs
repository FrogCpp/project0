using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public bool ActivateRagdoll;
    private Animator animator;
    [SerializeField] Rigidbody[] AllRagdollElements;
    [SerializeField] Walking Walking;
    void Start()
    {
        animator = GetComponent<Animator>();
        foreach (Rigidbody i in AllRagdollElements){
            i.isKinematic = true;
        }
    }
    void Update()
    {
        if (ActivateRagdoll)
        {
            foreach (Rigidbody i in AllRagdollElements)
            {
                i.isKinematic = false;
            }
            Walking.enabled = false;
            animator.enabled = false;
        }
    }
}
