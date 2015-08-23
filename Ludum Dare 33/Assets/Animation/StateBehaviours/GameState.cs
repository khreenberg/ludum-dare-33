using UnityEngine;

public class GameState : StateMachineBehaviour {

    private static bool _initialized = false;
    private static PlayerLauncher _playerLauncher;
    private static GameObjectMap _objectMap;
    private static EnemySpawner _spawner;

    private static int _isPlayingId = Animator.StringToHash("IsPlaying");
    private static int _isPausedId = Animator.StringToHash("IsPaused");

    [SerializeField]
    private int _spawnCount = 100;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        initIfNeeded();
        _playerLauncher.AwaitingInput = true;
        for( int i = 0; i < _spawnCount; i++)
        {
            Vector2 pos = new Vector2();
            pos.x = Random.Range(-2f, 2f);
            pos.y = Random.Range(_spawner.MinSpawnY, _spawner.MaxSpawnY);
            _spawner.Spawn(pos);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    private void initIfNeeded()
    {
        if (_initialized) return;
        _objectMap = GameObject.FindWithTag("StateMachine").GetComponent<GameObjectMap>();
        _playerLauncher = _objectMap.Get("PlayerLauncher").GetComponent<PlayerLauncher>();
        _spawner = _objectMap.Get("EnemySpawner").GetComponent<EnemySpawner>();
    }
}
