#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using System.Collections.Generic;
using UnityEngine;

public class GameObjectMap : MonoBehaviour
{

    private Dictionary<string, GameObject> _map = new Dictionary<string, GameObject>();

    [SerializeField]
    private GameObject[] _objects;

    public GameObject Get(string k)
    {
        GameObject v;
        bool inMap = _map.TryGetValue(k, out v);
        bool inArray = false;
        if (!inMap)
        {
            foreach (GameObject go in _objects)
            {
                if (!go.name.Equals(k)) continue;
                inArray = true;
                v = go;
                _map.Add(k, v);
            }
            if (!inArray) Debug.LogWarning(string.Format("GameObjectMap queried for {0}, but was not found.", k));
        }
        return v;
    }
}
#pragma warning restore 0649
