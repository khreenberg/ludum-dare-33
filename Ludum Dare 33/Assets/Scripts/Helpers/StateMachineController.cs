#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

public class StateMachineController : MonoBehaviour
{

    private static Animator _stateMachine;
    private static Animator StateMachine
    {
        get
        {
            if (_stateMachine == null)
            {
                _stateMachine = GameObject.FindWithTag("StateMachine").GetComponent<Animator>();
            }
            return _stateMachine;
        }
    }

    public static void SendFloat(string name, float value)
    {
        StateMachine.SetFloat(name, value);
    }

    public void SendInt(string name, int value)
    {
        StateMachine.SetInteger(name, value);

    }

    public void SendBool(string name, bool value)
    {
        StateMachine.SetBool(name, value);
    }

    public void SendTrigger(string name)
    {
        StateMachine.SetTrigger(name);
    }

    public void Send(string str)
    {
        var s = str.Split(' ');
        if (s.Length == 1) { SendTrigger(s[0]); return; }
        string name = s[0];

        float f;
        bool isFloat = float.TryParse(s[1], out f);
        if (isFloat) { SendFloat(name, f); return; }

        int i;
        bool isInt = int.TryParse(s[1], out i);
        if (isInt) { SendInt(name, i); return; }

        bool b;
        bool isBool = bool.TryParse(s[1], out b);
        if(isBool) { SendBool(name, b); return; }

        Debug.LogError(string.Format("StateMachine Error: Could not send value {0} to parameter {1}", s[1], s[0]));
    }
}
#pragma warning restore 0649
