using SRF;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PawnManager : Singleton<PawnManager>
{
    private PawnManager() { }

    public override void Initialize()
    {
        base.Initialize();

        GenerateNewPawn();
    }

    private void GenerateNewPawn()
    {
        var pawnRes = Resources.Load("Prefabs/Character/Pawn");
        var curPawn = GameObject.Instantiate(pawnRes);
        curPawn.GetComponent<Transform>().ResetLocal();
    }

    public override void Tick()
    {
        base.Tick();

        Debug.Log("Tick PawnManager");
    }
}
