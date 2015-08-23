#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

[RequireComponent(typeof(Entity))]
public abstract class RoamMovement : MonoBehaviour
{
    protected abstract Vector2 Point { get; set; }
    protected delegate void PointReachedDelegate();
    protected event PointReachedDelegate OnPointReached;

    private Entity _entity;

    public void Awake()
    {
        _entity = GetComponent<Entity>();
    }

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Point, _entity.Stats.MoveSpeed * Time.deltaTime);
        if ((Vector2) transform.position == Point) OnPointReached();
    }
}
#pragma warning restore 0649
