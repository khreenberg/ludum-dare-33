#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using System.Collections.Generic;
using UnityEngine;

public class ShowHideGameObjects : StateMachineBehaviour
{
    [SerializeField]
    private bool _autoReverse = false;

    [SerializeField]
    private string[] _deactivate, _activate;

    private static GameObjectMap _objectMap;
    private Dictionary<GameObject, bool> _activityMap;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_objectMap == null) _objectMap = GameObject.FindWithTag("StateMachine").GetComponent<GameObjectMap>();
        if (_autoReverse) _activityMap = new Dictionary<GameObject, bool>();
        foreach (string s in _deactivate)
        {
            GameObject g = _objectMap.Get(s);
            if (_autoReverse) _activityMap.Add(g, g.activeSelf);
            g.SetActive(false);
        }

        foreach (string s in _activate)
        {
            GameObject g = _objectMap.Get(s);
            if (_autoReverse) _activityMap.Add(g, g.activeSelf);
            g.SetActive(true);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_autoReverse) return;
        foreach (KeyValuePair<GameObject, bool> kvPair in _activityMap)
        {
            kvPair.Key.SetActive(kvPair.Value);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
#pragma warning restore 0649
