using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleWork
{
    public Action WorkAction => workAction;

    private WorkStateEnum workState;
    private WorkTypeEnum workType;
    private Action workAction;

    public SingleWork(WorkStateEnum workState, WorkTypeEnum workType, Action workAction)
    {
        this.workState = workState;
        this.workType = workType;
        this.workAction = workAction;
    }
}
