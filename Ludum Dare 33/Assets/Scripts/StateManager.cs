//#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
//using System.Collections.Generic;
//using UnityEngine;

//public class StateManager : MonoBehaviour
//{
//    public enum StateName
//    {
//        TITLE, HELP, PAUSE, GAME_BEGIN, GAME_RUN, GAME_OVER
//    }

//    [SerializeField]
//    private GameObject _titleScreen, _helpScreen, _pauseScreen, _gameScreen, _gameOverScreen;

//    private Dictionary<StateName, State> _stateMap = new Dictionary<StateName, State>();
//    private State _currentState;

//    void Awake()
//    {

//    }

//    void Update()
//    {
//        _currentState.OnUpdate();
//    }

//    public void SetState(StateName stateName)
//    {
//        State state;
//        bool exists;
//        switch(stateName)
//        {
//            case StateName.TITLE:
//                exists = _stateMap.TryGetValue(StateName.TITLE, out state);
//                if (!exists)
//                {
//                    state = new TitleState(_titleScreen);
//                    _stateMap.Add(StateName.TITLE, state);
//                }
//                break;
//            case StateName.HELP:
//                exists = _stateMap.TryGetValue(StateName.HELP, out state);
//                if (!exists)
//                {
//                    state = new TitleState(_titleScreen);
//                    _stateMap.Add(StateName.TITLE, state);
//                }
//                break;
//            case StateName.PAUSE:
//                break;
//            case StateName.GAME_BEGIN:
//                break;
//            case StateName.GAME_RUN:
//                break;
//            case StateName.GAME_OVER:
//                break;
//            default:
//                Debug.LogError("No such state: " + stateName);
//                break; // C# sucks.
//        }
//        _currentState = state;
//    }

//    // --- States --- //
//    abstract class State
//    {
//        public abstract void OnEnter();
//        public abstract void OnUpdate();
//        public abstract void OnLeave();
//    }

//    private class TitleState : State
//    {
//        private GameObject _titleScreen;

//        public TitleState(GameObject titleScreen)
//        {
//            _titleScreen = titleScreen;
//        }

//        public override void OnEnter()
//        {
//            _titleScreen.SetActive(true);
//        }

//        public override void OnUpdate(){}

//        public override void OnLeave()
//        {
//        }

//    }
//}
//#pragma warning restore 0649
