#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using System;
using UnityEngine;

[Obsolete]
[RequireComponent(typeof(Rigidbody2D))]
public class BasicMovement : MonoBehaviour
{
    public Vector2 MoveSpeed = new Vector2(0, 0);

    private Rigidbody2D _rb;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.MovePosition((Vector2)transform.position + MoveSpeed * Time.deltaTime);
    }
}
#pragma warning restore 0649
