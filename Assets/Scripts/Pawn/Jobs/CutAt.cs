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
    public class CutAt : Sequence
    {
        public Vector2Int pos;
        public Humanbeing human;

        public CutAt(Vector2Int pos, Humanbeing human)
        {
            this.pos = pos;
            this.human = human;
        }
    }
}
