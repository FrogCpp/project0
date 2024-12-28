using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shuting : MonoBehaviour
{
    [SerializeField] private float SpreadRadius, Distance, Interval;
    [SerializeField] private UserInput UserI;
    private Vector3 _rayForward;
    private Ray _ray;
    private UserInput _inp;
    private float _recovery;
    void Start()
    {
        _inp = UserI;
    }
    void Update()
    {
        if (_inp.Fire)
        {
            if (_recovery == 0f)
            {
                _rayForward = transform.up;
                _ray = new Ray(transform.position, SpreadGener(_rayForward, SpreadRadius));
                Debug.DrawRay(transform.position, SpreadGener(_rayForward, SpreadRadius) * Distance, Color.red);
                if (Physics.Raycast(_ray, out RaycastHit collid, Distance))
                {
                    if (collid.collider.gameObject.TryGetComponent<DamageForBuildin>(out DamageForBuildin o))
                    {
                        o.Damage(collid.point);
                    }
                }
                _recovery = Interval;
            }
            else
            {
                _recovery -= Time.deltaTime;
                if (_recovery < 0f)
                    _recovery = 0f;

            }
        }
        else
        {
            _recovery = 0;
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
