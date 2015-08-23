#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class EnemyMovement : MonoBehaviour
{

    public Transform[] Waypoints;

    private Entity _entity;
    private int _nextWaypointIndex = 0;

    void Awake()
    {
        _entity = GetComponent<Entity>();
    }

    void Update()
    {
        if (Waypoints == null || Waypoints.Length == 0) return;
        Transform next = Waypoints[_nextWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, next.position, _entity.Stats.MoveSpeed * Time.deltaTime);
        if (transform.position != next.position) return;
        _nextWaypointIndex++;
        if (_nextWaypointIndex >= Waypoints.Length) _nextWaypointIndex = 0;
    }
}
#pragma warning restore 0649
