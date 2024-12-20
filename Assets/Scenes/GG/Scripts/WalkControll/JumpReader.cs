using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpReader : MonoBehaviour
{
    public bool touch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Buildings")
            touch = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Buildings")
            touch = false;
    }
}
