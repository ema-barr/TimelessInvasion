using UnityEngine;
using UnityEditor;

[System.Serializable]
public abstract class State<T>
{
    public abstract void EnterState(T owner);
    public abstract void ExitState(T owner);
    public abstract void ExecuteState(T owner);
}