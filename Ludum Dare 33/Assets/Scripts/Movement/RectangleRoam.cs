#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

public class RectangleRoam : RoamMovement
{

    [SerializeField]
    private Transform _corner1, _corner2;

    private Vector2 _point;
    protected override Vector2 Point
    {
        get
        {
            return _point;
        }

        set
        {
            _point = value;
        }
    }

    new void Awake()
    {
        base.Awake(); // ffs Unity. Get a grip!
        OnPointReached += setNextPoint;
        setNextPoint();
    }

    new void Update()
    {
        base.Update(); // grrr
    }

    private void setNextPoint()
    {
        float left = Mathf.Min(_corner1.position.x, _corner2.position.x);
        float right = Mathf.Max(_corner1.position.x, _corner2.position.x);
        float top = Mathf.Max(_corner1.position.y, _corner2.position.y);
        float bottom = Mathf.Min(_corner1.position.y, _corner2.position.y);
        Point = new Vector2(Random.Range(left, right), Random.Range(bottom, top));
    }
}
#pragma warning restore 0649
