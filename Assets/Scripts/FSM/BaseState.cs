using LittleWorld.GameStateSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected GameState stateID;
    public GameState StateID { get => stateID; }
    public Dictionary<TransitionEnum, GameState> transitionDic;
    public FiniteStateMachine finiteStateMachine;

    /// <summary>
    /// 状态开始
    /// </summary>
    public virtual void OnStateStart()
    {

    }

    /// <summary>
    /// 状态更新
    /// </summary>
    public virtual void OnStateUpdate()
    {

    }

    /// <summary>
    /// 状态结束
    /// </summary>
    public virtual void OnStateEnd()
    {

    }

    /// <summary>
    /// 状态切换检测
    /// </summary>
    public virtual void OnStateCheckTransition()
    {

    }

    /// <summary>
    /// 状态机重置状态时
    /// </summary>
    public virtual void OnReset()
    {

    }

    /// <summary>
    /// 状态机重置数据
    /// </summary>
    public virtual void OnClear()
    {

    }

    public void AddTransition(TransitionEnum transition, GameState stateID)
    {
        if (transitionDic.ContainsKey(transition))
        {
            return;
        }
        transitionDic.Add(transition, stateID);
    }

    public void RemoveTransition(TransitionEnum transition)
    {
        if (transitionDic.ContainsKey(transition))
        {
            transitionDic.Remove(transition);
        }
    }

    public BaseState(GameState stateID)
    {
        this.transitionDic = new Dictionary<TransitionEnum, GameState>();
        this.stateID = stateID;
    }
}
