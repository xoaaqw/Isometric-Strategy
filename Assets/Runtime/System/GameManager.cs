using Services;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Service,IService
{
    public override Type RegisterType => GetType();
    [SerializeField]
    private SerializedHashSet<PawnEntity> pawns = new();

    public Action<int,int> AfterTimeChange;
    public Action OnStartBattle;

    private int time;
    public int Time
    {
        get => time; 
        set
        {
            if(time != value)
            {
                int prev = time;
                time = value;
                AfterTimeChange.Invoke(prev, time);
            }
        }
    }

    public List<PawnAction> actionList;


    public void Register(PawnEntity entity)
    {
        pawns.Add(entity);
    }
    public void Unregister(PawnEntity entity)
    {
        pawns.Remove(entity);
    }

    public void StartBattle()
    {
        time = 0;
        OnStartBattle?.Invoke();
        MoveOn();
    }

    public bool MoveOn()
    {
        //TODO:ս�������ж�
        foreach(PawnEntity pawn in pawns)
        {
            if (Time >= pawn.State.waitTime)
            {
                pawn.DoAction();
                return false;
            }
        }
        Time++;
        return true;
    }
}