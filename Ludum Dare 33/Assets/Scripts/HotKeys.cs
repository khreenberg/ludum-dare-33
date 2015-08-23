#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

public class HotKeys : MonoBehaviour {

    [SerializeField]
    private StateMachineController _stateController;

    void Update()
    {
        ActualKeys();
        DebugKeys();
    }

    void ActualKeys()
    {

    }

    void DebugKeys()
    {
#if UNITY_EDITOR
#endif
    }
}
#pragma warning restore 0649
