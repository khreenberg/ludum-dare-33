#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using System;
using UnityEngine;

public class KnightChase : RoamMovement
{
    public Transform Target { get; set; }
    protected override Vector2 Point
    {
        get {
            if(Target == null)
            {
                enabled = false;
                GetComponent<EnemyMovement>().enabled = true;
                return Vector2.zero;
            }
            return Target.position; }
        set { /* Do nothing */ }
    }

    new void Awake() { base.Awake(); }
    new void Update() { base.Update(); }
}
#pragma warning restore 0649
