#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Entity))]
public class PlayerMovement : MonoBehaviour
{
    public bool CanMove = true;
    private Rigidbody2D _rb;
    private Entity _entity;
    private Animator _anim;

    private int _moveSpeedId = Animator.StringToHash("MoveSpeed");

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _entity = GetComponent<Entity>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = CanMove ? _entity.Stats.MoveSpeed : 0;
        _anim.SetFloat(_moveSpeedId, speed);
        Vector2 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        _rb.MovePosition(pos);
    }
}
#pragma warning restore 0649
