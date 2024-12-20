using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator _animator;
    private UserInput _userInput;
    void Start()
    {
        _userInput = GetComponent<UserInput>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        _animator.SetFloat("Hori", _userInput.Hori);
        _animator.SetFloat("Vert", _userInput.Vert);
        _animator.SetFloat("Run", _userInput.Shift);
        _animator.SetBool("OnAir", _userInput.OnAir);
    }
}
