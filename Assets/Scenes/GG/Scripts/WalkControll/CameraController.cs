using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float Range, SpeedK;
    [SerializeField] private GameObject Target;
    [SerializeField] private Transform RecoilTarget;
    [SerializeField] private UserInput Inp;
    private Quaternion _rot;
    private float _recoil;
    void Start()
    {
    }
    void Update()
    {
        _recoil = Inp.Recoil;
        Inp.Recoil = 0f;
        transform.LookAt(Target.transform);
        var a = (RecoilTarget.position - Target.transform.position) * SpeedK;
        a.y += _recoil;
        Target.transform.position += a;


        var b = Target.transform.position - transform.position;
        var distance = b.magnitude;
        a = transform.localPosition;
        a.z += ((distance - Range) > 0.05f ? distance - Range : 0f);
        a.z += ((distance - Range) < -0.05f ? distance - Range : 0f);
        transform.localPosition = a;
    }
}
