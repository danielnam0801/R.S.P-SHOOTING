using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0f;
    [SerializeField]
    private Vector3 dir = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * _speed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        dir = direction;
    }
}
