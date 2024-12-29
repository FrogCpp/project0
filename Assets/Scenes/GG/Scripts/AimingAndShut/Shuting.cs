using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Shuting : MonoBehaviour
{
    [SerializeField] private float SpreadRadius, Distance, Interval, Recoil;
    [SerializeField] private UserInput UserI;
    private Vector3 _rayForward;
    private Ray _ray;
    private UserInput _inp;
    private float _rollback;
    void Start()
    {
        _inp = UserI;
    }
    void Update()
    {
        if (_inp.Fire)
        {
            if (_rollback == 0f)
            {
                _rayForward = transform.up;
                _ray = new Ray(transform.position, SpreadGener(_rayForward, SpreadRadius));
                Debug.DrawRay(transform.position, SpreadGener(_rayForward, SpreadRadius) * Distance, Color.red);
                if (Physics.Raycast(_ray, out RaycastHit collid, Distance))
                {
                    Damage o = collid.collider.gameObject.GetComponentInParent<Damage>();
                    if (o != null)
                    {
                        o.DamageReact(collid.point, collid.collider.tag);
                    }
                }
                _rollback = Interval;
                _inp.Recoil = Recoil;
            }
            else
            {
                _rollback -= Time.deltaTime;
                if (_rollback < 0f)
                    _rollback = 0f;

            }
        }
        else
        {
            _rollback = 0;
        }
    }

    Vector3 SpreadGener(Vector3 ray, float radius)
    {
        ray.y += Random.Range(-radius, radius);
        ray.z += Random.Range(-radius, radius);
        ray.x += Random.Range(-radius, radius);
        return ray;
    }
}
