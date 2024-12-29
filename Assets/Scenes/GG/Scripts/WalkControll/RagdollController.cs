using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public bool ActivateRagdoll;
    private Animator _animator;
    [SerializeField] Rigidbody[] AllRagdollElements;
    private Walking _walking;
    private UserInput _userInput;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _walking = GetComponent<Walking>();
        _userInput = GetComponent<UserInput>();
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
            _walking.enabled = false;
            _animator.enabled = false;
            _userInput.enabled = false;
        }
    }
}
