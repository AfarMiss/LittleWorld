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

    public void AddPawn(Humanbeing human)
    {
        pawns.Add(human);
    }

    public override void Tick()
    {
        base.Tick();
    }
}
