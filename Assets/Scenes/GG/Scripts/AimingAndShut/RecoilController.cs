using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RecoilController : MonoBehaviour
{
    [SerializeField] private UserInput _inp;
    [SerializeField] private float VerticalRotate, Up, Down;
    [SerializeField] private Transform Target, CameraPose;
    void Start()
    {
        transform.position = Target.transform.position;
    }
    void Update()
    {
        var a = transform.position;
        a.y += _inp.MouseVert * VerticalRotate;
        if (a.y > CameraPose.position.y + Up)
            a.y = CameraPose.position.y + Up;
        if (a.y < CameraPose.position.y - Down)
            a.y = CameraPose.position.y - Down;
        transform.position = a;
    }
}
