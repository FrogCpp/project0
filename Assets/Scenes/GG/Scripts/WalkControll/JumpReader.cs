using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpReader : MonoBehaviour
{
    public bool touch;
    [SerializeField] private Collider[] Ignore;
    private void OnTriggerStay(Collider other)
    {
        bool a = true;
        foreach (Collider c in Ignore)
            a = other != c;
        if (a)
            touch = true;
    }
    private void OnTriggerExit(Collider other)
    {
        bool a = true;
        foreach (Collider c in Ignore)
            a = other != c;
        if (a)
            touch = false;
    }
}
