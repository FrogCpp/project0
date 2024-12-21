using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CameraController : MonoBehaviour
{
    [SerializeField] private UserInput _inp;
    [SerializeField] private float VerticalRotate, Up, Down, Range;
    [SerializeField] private GameObject Target;
    private Quaternion _rot;
    void Start()
    {
    }
    void Update()
    {
        transform.LookAt(Target.transform);
        var a = Target.transform.position;
        a.y += _inp.MouseVert * VerticalRotate;
        if (a.y > transform.position.y + Up)
            a.y = transform.position.y + Up;
        if (a.y < transform.position.y - Down)
            a.y = transform.position.y - Down;
        Target.transform.position = a;
        
        var b =Target.transform.position - transform.position;
        var distance = b.magnitude;
        a = transform.localPosition;
        a.z += ((distance - Range) > 0.05f ? distance - Range : 0f);
        a.z += ((distance - Range) < -0.05f ? distance - Range : 0f);
        transform.localPosition = a;  
    }
}
