using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour, IRotable
{
    [SerializeField] float rotateSpeed;
    private void Update()
    {
        Rotable();
    }

    public void Rotable()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
    }
}
