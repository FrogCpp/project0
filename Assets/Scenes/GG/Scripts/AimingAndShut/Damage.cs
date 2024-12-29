using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private GameObject System;
    [SerializeField] private bool IsPlayer;
    private RagdollController _deadSystem;
    private float Hp = 200;
    private void Start()
    {
        _deadSystem = gameObject.GetComponent<RagdollController>();
    }
    public void DamageReact(Vector3 coords, string tag)
    {
        if (IsPlayer)
        {
            if (tag == "Head")
                Hp -= 150;
            if (tag == "Arm")
                Hp -= 30;
            if (tag == "Legs")
                Hp -= 45;
            if (tag == "Body")
                Hp -= 100;
            if (Hp < 0f)
                _deadSystem.ActivateRagdoll = true;
        }
        else
        {
            var a = Instantiate(System);
            a.transform.position = coords;
        }
    }
}
