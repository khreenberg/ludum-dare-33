#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform[] Waypoints;
    public float MoveSpeed = .5f;

    private int _nextWaypointIndex = 0;

    void Update()
    {
        if (Waypoints == null || Waypoints.Length == 0) return;
        Transform next = Waypoints[_nextWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, next.position, MoveSpeed*Time.deltaTime);
        if (transform.position != next.position) return;
        _nextWaypointIndex++;
        if (_nextWaypointIndex >= Waypoints.Length) _nextWaypointIndex = 0;
    }
}
#pragma warning restore 0649
