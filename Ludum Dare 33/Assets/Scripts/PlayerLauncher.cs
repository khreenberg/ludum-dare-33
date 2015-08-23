#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{

    private int _gameState = Animator.StringToHash("Base Layer.Game");
    private Animator _stateMachine;

    [SerializeField]
    private float _yOffset = .5f;

    [SerializeField]
    private Entity _player;

    [SerializeField]
    [Range(0, 1)]
    private float _waitAlpha = .5f;

    private Camera _mainCam;
    private float _bottom;

    private bool _awaitingInput;
    public bool AwaitingInput
    {
        get
        {
            return _awaitingInput;
        }
        set
        {
            _awaitingInput = value;
            Color c = _player.GetComponent<SpriteRenderer>().material.color;
            c.a = _awaitingInput ? _waitAlpha : 1.0f;
            _player.GetComponent<SpriteRenderer>().material.color = c;
        }
    }

    void Awake()
    {
        _mainCam = Camera.main;
        _bottom = -_mainCam.orthographicSize;
        _stateMachine = GameObject.FindWithTag("StateMachine").GetComponent<Animator>();
    }

    void LateUpdate()
    {
        if (!AwaitingInput) return;
        if (_stateMachine.GetCurrentAnimatorStateInfo(0).fullPathHash != _gameState) return;
        Vector2 pos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        pos.y = _bottom + _yOffset;
        _player.transform.position = pos;
        if (Input.GetMouseButtonDown(0)) AwaitingInput = false;
    }
}
#pragma warning restore 0649
