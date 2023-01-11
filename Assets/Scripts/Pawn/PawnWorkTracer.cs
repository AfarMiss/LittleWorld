using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnWorkTracer
{
    public PawnWorkTracer(Pawn pawn)
    {
        this.pawn = pawn;
        workQueue = new Queue<SingleWork>();
    }
    private Pawn pawn;
    public Queue<SingleWork> WorkQueue => workQueue;
    private Queue<SingleWork> workQueue;

    private WorkTypeEnum curWork;

    public bool AddWork(SingleWork singleWork)
    {
        workQueue.Enqueue(singleWork);
        return true;
    }

    public bool GetCurrentWorkAndStart()
    {
        var curWork = workQueue.Dequeue();
        curWork.WorkAction();
        return true;
    }
}
