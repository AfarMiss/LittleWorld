using LittleWorldObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : WorldObject
{
    private PawnWorkTracer pawnWorkTracer;
    public Pawn()
    {
        pawnWorkTracer = new PawnWorkTracer(this);
    }
}
