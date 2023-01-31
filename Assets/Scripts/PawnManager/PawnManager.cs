using LittleWorld.Item;
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

    public override void OnCreateInstance()
    {
        base.OnCreateInstance();

        pawns = new List<Humanbeing>();
    }

    private void RenderPawn(Vector3Int pos, Humanbeing human)
    {
        var pawnRes = Resources.Load("Prefabs/Character/Pawn");
        var curPawn = GameObject.Instantiate(pawnRes);
        curPawn.GetComponent<Transform>().transform.position = pos;
        curPawn.GetComponent<PathNavigation>().Initialize(human.instanceID);
        curPawn.GetComponent<ItemRender>().Init(human.itemCode);
        human.SetNavi(curPawn.GetComponent<PathNavigation>());

    }

    public void AddPawn(Humanbeing human)
    {
        pawns.Add(human);
        RenderPawn(human.GridPos.To3(), human);
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
