using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public delegate void EventMethod();

    public event EventMethod OnPlayerMove;
    public event EventMethod OnBattleStart;

    public void FireOnPlayerMove()
    {
        if (OnPlayerMove != null)
            OnPlayerMove();
    }
    public void FireOnBattleStart()
    {
        if (OnBattleStart != null)
            OnBattleStart();
    }
}
