using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace LittleWorld.Command
{
    public class TransportPodCommand : ICommand
    {
        public List<WorldObject> content;
        public Vector2Int landpoint;

        public TransportPodCommand(Vector2Int landpoint, List<WorldObject> content = null)
        {
            this.content = content;
            this.landpoint = landpoint;
        }

        public void Execute()
        {
            SceneObjectManager.Instance.Landing(landpoint);
            TimerManager.Instance.RegisterTimer(new Timer(TimerName.ON_LANDED, SceneObjectManager.Instance.landingDuration,
                onComplete: () =>
                {
                    new Building(14007, landpoint, BuildingStatus.Done);
                }));
        }
    }
}
