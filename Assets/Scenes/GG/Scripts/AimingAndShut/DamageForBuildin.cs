using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageForBuildin : MonoBehaviour
{
    [SerializeField] private GameObject System;
    public void Damage(Vector3 coords)
    {
        var a = Instantiate(System);
        a.transform.position = coords;
    }
}
