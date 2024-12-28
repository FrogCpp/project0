using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public float Vert = 0, Hori = 0, MouseHori, MouseVert, Shift, Jump;
    public bool OnAir = false, Fire;
    [SerializeField] private float kWalk;
    [SerializeField] private JumpReader Trigg;
    void Update()
    {
        float V = Input.GetAxis("Vertical");
        float H = Input.GetAxis("Horizontal");
        float S = Input.GetAxis("Shift");
        Vert += (Mathf.Abs(Vert - V) < 0.01f ? 0f : (Vert - V) * -kWalk);
        Hori += (Mathf.Abs(Hori - H) < 0.01f ? 0f : (Hori - H) * -kWalk);
        Shift += (Mathf.Abs(Shift - S) < 0.01f ? 0f : (Shift - S) * -kWalk);
        Vert = Mathf.Round(Vert * 100) / 100;
        Hori = Mathf.Round(Hori * 100) / 100;
        Shift = Mathf.Round(Shift * 100) / 100;
        MouseVert = Input.GetAxis("Mouse Y");
        MouseHori = Input.GetAxis("Mouse X");
        Jump = Input.GetAxis("Jump");
        Fire = Input.GetAxis("Fire1") != 0f;
        OnAir = !Trigg.touch;
    }
}
