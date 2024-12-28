using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private float SpreadRadius, Distance;
    [SerializeField] private GameObject TargetToAim;
    private Vector3 _rayForward;
    private Ray _ray;
    void Start()
    {
    }
    void Update()
    {
        _rayForward = transform.forward;
        _ray = new Ray(transform.position, SpreadGener(_rayForward, SpreadRadius));
        Debug.DrawRay(transform.position, SpreadGener(_rayForward, SpreadRadius) * Distance, Color.red);
        if (Physics.Raycast(_ray, out RaycastHit collid, Distance))
        {
            TargetToAim.transform.position = collid.point;
        }
        else
        {
            TargetToAim.transform.position = _ray.GetPoint(Distance);
        }
    }

    Vector3 SpreadGener(Vector3 ray, float radius)
    {
        ray.y += Random.Range(0f, radius);
        ray.z += Random.Range(0f, radius);
        ray.x += Random.Range(0f, radius);
        return ray;
    }
}
