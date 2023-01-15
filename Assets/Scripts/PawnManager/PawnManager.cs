using LittleWorldObject;
using SRF;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PawnManager : Singleton<PawnManager>
{
    private PawnManager()
    {
    }

    public List<Humanbeing> Pawns => pawns;
    private List<Humanbeing> pawns;

    public override void Initialize()
    {
        base.Initialize();

        pawns = new List<Humanbeing>();
    }

    private void RenderPawn(Vector3Int pos, Humanbeing human)
    {
        var pawnRes = Resources.Load("Prefabs/Character/Pawn");
        var curPawn = GameObject.Instantiate(pawnRes);
        curPawn.GetComponent<ItemRender>().Init(10026);
        curPawn.GetComponent<Transform>().transform.position = pos;
        curPawn.GetComponent<PathNavigationOnly>().Initialize(human.instanceID);
    }

    public void AddPawn(Humanbeing human)
    {
        pawns.Add(human);
        RenderPawn(human.GridPos, human);
    }

    public override void Tick()
    {
        base.Tick();
        foreach (var pawn in pawns)
        {
            pawn.Tick();
        }
    }
}
