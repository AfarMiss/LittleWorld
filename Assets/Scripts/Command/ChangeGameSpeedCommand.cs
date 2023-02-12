using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Command
{
    public class ChangeGameSpeedCommand : ICommand
    {
        private float timeSpeed;

        public ChangeGameSpeedCommand(float timeSpeed)
        {
            this.timeSpeed = timeSpeed;
        }

        public void Execute()
        {
            Current.CurGame.timeSpeed = (int)timeSpeed;
        }
    }
}
