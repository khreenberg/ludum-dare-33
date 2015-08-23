#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

public class HotKeys : MonoBehaviour {

    private Animator _stateMachine;
    private readonly int _isPausedId = Animator.StringToHash("IsPaused");

    void Awake()
    {
        _stateMachine = GameObject.FindWithTag("StateMachine").GetComponent<Animator>();
    }

    void Update()
    {
        ActualKeys();
        DebugKeys();
    }

    void ActualKeys()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _stateMachine.SetBool(_isPausedId, true);
        }
    }

    void DebugKeys()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R)) // Reset...ish.
        {
            GameObject.Find("PlayerLauncher").GetComponent<PlayerLauncher>().AwaitingInput = true;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().CanMove = true;
        }
#endif
    }
}
#pragma warning restore 0649
