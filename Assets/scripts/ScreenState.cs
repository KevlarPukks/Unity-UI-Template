using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScreenState 
{
    public ScreenStates state;
    public GameObject screen;
    public UnityEvent onTransitionStart;
    public UnityEvent onTransitionComplete;
}
