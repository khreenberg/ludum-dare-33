#pragma warning disable 0649
using UnityEngine;

[ExecuteInEditMode]
public class TilingHelper : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField]
    private int _rows, _cols;

    [SerializeField]
    private GameObject _tile;

    [SerializeField]
    private float _tileWidth, _tileHeight;

    [SerializeField]
    private bool _button;

    private GameObject _container;

    void Update()
    {
        if (!_button) return;
        _button = false;
        clearContainer();
        for (int r = 0; r < _rows; r++)
        {
            float left = (_rows * _tileHeight) / 2 - _rows * _tileHeight;
            float y = left + r * _tileHeight;
            for (int c = 0; c < _cols; c++)
            {
                float top = (_cols * _tileWidth) / 2 - _cols * _tileWidth;
                float x = top + c * _tileWidth;
                GameObject t = Instantiate(_tile, new Vector2(x, y), Quaternion.identity) as GameObject;
                t.name = string.Format("{0}({1},{2})", _tile.name, r, c);
                t.transform.parent = _container.transform;
            }
        }
    }

    void clearContainer()
    {
        if (_container) DestroyImmediate(_container);
        _container = new GameObject(string.Format("{0} container", _tile.name));
    }

    public void OnDisable()
    {
        if (_container) DestroyImmediate(_container);
    }


#endif
}
#pragma warning restore 0649