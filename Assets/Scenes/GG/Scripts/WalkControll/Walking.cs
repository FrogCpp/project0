using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] private float Walk, Run, Jump, Crouch, HorizontalRotate;
    private UserInput _inp;
    private Vector3 _myCoords;
    private Rigidbody _rb;
    private float Vert, Hori, _angHori = 0f, Shift, Space;
    void Start()
    {
        _inp = GetComponent<UserInput>();
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vert = _inp.Vert;
        Hori = _inp.Hori;
        Shift = _inp.Shift;
        Space = _inp.Jump;
        _angHori += _inp.MouseHori * HorizontalRotate;
        _angHori = (_angHori > 360f ? 0f : _angHori);
        _angHori = (_angHori < 0f ? 360f : _angHori);

        float n = 0f, m = 0f, keyAng, globalAng;

        keyAng = Mathf.Acos(Vert / (Mathf.Sqrt((Hori * Hori) + (Vert * Vert)))) * Mathf.Sign(Hori);

        globalAng = (keyAng / Mathf.PI * 180) + _angHori;

        n = (Mathf.Sin(globalAng / 180 * Mathf.PI)) * (Walk + (Shift > 0 ? Run * Shift : Crouch * Shift));
        m = (Mathf.Cos(globalAng / 180 * Mathf.PI)) * (Walk + (Shift > 0 ? Run * Shift : Crouch * Shift));
        if (Hori == 0f && Vert == 0f)
        {
            n = 0f;
            m = 0f;
        }
        if (Space != 0f && !_inp.OnAir)
            _rb.AddRelativeForce(Vector3.up * Jump);
        _rb.velocity = new Vector3(n, _rb.velocity.y, m);



        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        Vector3 rotationToAdd = new Vector3(0, _angHori, 0);
        transform.Rotate(rotationToAdd);
    }
}
