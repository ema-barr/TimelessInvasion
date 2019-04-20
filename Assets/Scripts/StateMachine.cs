using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateMachine<T>
{
    public State<T> currentState { get; set; }
    public State<T> previousState { get; set; }
    public State<T> globalState { get; set; }

    public T owner;

    public StateMachine(T _o)
    {
        owner = _o;
        currentState = null;
        previousState = null;
        globalState = null;
    }

    public void ChangeState(State<T> _newState)
    {
        previousState = currentState;

        if (currentState != null)
            currentState.ExitState(owner);

        currentState = _newState;
        currentState.EnterState(owner);
    }

    public void Update()
    {
        if (globalState != null)
        {
            globalState.ExecuteState(owner);
        }

        if (currentState != null)
            currentState.ExecuteState(owner);
    }

    public void RevertToPreviousState()
    {
        ChangeState(previousState);
    }

}




