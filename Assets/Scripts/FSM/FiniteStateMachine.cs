using System.Collections.Generic;

public class FiniteStateMachine
{
    /// <summary>
    /// 当前状态
    /// </summary>
    public BaseState curState;
    /// <summary>
    /// 默认状态
    /// </summary>
    public BaseState defaultState;
    /// <summary>
    /// 状态字典
    /// </summary>
    private Dictionary<StateEnum, BaseState> statesDic;

    public void SetDefaultState(BaseState state)
    {
        defaultState = state;
    }

    public void Start()
    {
        curState = defaultState;
        curState.OnStateStart();
    }

    public void Update()
    {
        curState.OnStateUpdate();
        curState.OnStateCheckTransition();
    }

    public void OnDestroy()
    {
        curState.OnStateEnd();
    }

    public FiniteStateMachine()
    {
        statesDic = new Dictionary<StateEnum, BaseState>();
    }

    /// <summary>
    /// 重置FSM状态[不清除数据]
    /// </summary>
    public virtual void ResetState()
    {
        foreach (var item in statesDic)
        {
            item.Value.OnReset();
        }
        curState = defaultState;
        curState.OnStateStart();
    }

    /// <summary>
    /// 重置FSM状态[清除数据]
    /// </summary>
    public virtual void ResetData()
    {
        foreach (var item in statesDic)
        {
            item.Value.OnClear();
        }
        curState = defaultState;
        curState.OnStateStart();
    }

    public void AddState(BaseState state)
    {
        if (!statesDic.ContainsKey(state.StateID))
        {
            statesDic.Add(state.StateID, state);
            state.finiteStateMachine = this;
        }
    }

    public void RemoveState(BaseState state)
    {
        if (statesDic.ContainsKey(state.StateID))
        {
            statesDic.Remove(state.StateID);
        }
    }

    public void Transform(TransitionEnum transition)
    {
        if (curState.transitionDic.ContainsKey(transition))
        {
            curState.OnStateEnd();

            var curStateID = curState.transitionDic[transition];
            curState = statesDic[curStateID];
            curState.OnStateStart();
        }
    }
}