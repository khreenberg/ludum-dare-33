#pragma warning disable 0649
using UnityEngine;

[ExecuteInEditMode]
public class PixelSnap : MonoBehaviour
{

    public const int PPU = 100;
    [SerializeField]
    private bool _oddX, _oddY;

    void Update()
    {
        transform.position = snapVector(transform.position);
    }

    Vector3 snapVector(Vector3 vec)
    {
        float xOffset = _oddX ? .5f / PPU : 0;
        float yOffset = _oddY ? .5f / PPU : 0;
        return new Vector3(snapFloat(vec.x + xOffset), snapFloat(vec.y + yOffset), snapFloat(vec.z));
    }

    float snapFloat(float f)
    {
        return Mathf.Round(f * PPU) / PPU;
    }
}
#pragma warning restore 0649
