using BehaviourTreeUtility;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using LittleWorld.Message;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static BehaviourTreeUtility.RobberBehaviour;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace LittleWorld.Jobs
{
    public class CutAreaLoop : ConditionLoop
    {
        public MapGridDetails[] grids;
        public Humanbeing human;

        public CutAreaLoop(MapGridDetails[] grids, Humanbeing human, Tick tick) : base(tick)
        {
            this.grids = grids;
            this.human = human;
        }
    }
}
