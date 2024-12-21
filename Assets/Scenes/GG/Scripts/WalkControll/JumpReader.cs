using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpReader : MonoBehaviour
{
    public bool touch;
    private void OnTriggerStay(Collider other)
    {
        touch = true;
    }
    private void OnTriggerExit(Collider other)
    {
        touch = false;
    }
}
