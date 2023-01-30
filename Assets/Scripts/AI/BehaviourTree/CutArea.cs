using BehaviourTreeUtility;
using LittleWorld.Item;
using LittleWorld.Message;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static BehaviourTreeUtility.RobberBehaviour;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace LittleWorld.Jobs
{
    public class CutArea : Sequence
    {
        public Vector2Int[] grids;
        public Humanbeing human;

        public CutArea(Vector2Int[] grids, Humanbeing human)
        {
            this.grids = grids;
            this.human = human;
        }
    }
}
