#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

public class AutoFlipper : MonoBehaviour {

    private Vector2 _lastPos;
    private bool _isMovingRight;

    [SerializeField]
    private bool _rightIsDefault = true;

    void Start()
    {
        _isMovingRight = _rightIsDefault;
    }

    void LateUpdate()
    {
        bool flip = shouldFlip();
        _lastPos = transform.position;
        if (!flip) return;
        _isMovingRight = !_isMovingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    bool shouldFlip()
    {
        Vector2 pos = transform.position;
        if (pos.x == _lastPos.x) return false;
        bool movingRight = pos.x > _lastPos.x;
        return movingRight != _isMovingRight;
    }
}
#pragma warning restore 0649
