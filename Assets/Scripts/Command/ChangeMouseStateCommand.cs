using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Command
{
    public class ChangeMouseStateCommand : ICommand
    {
        private MouseState mouseState;
        public ChangeMouseStateCommand(MouseState mouseState)
        {
            this.mouseState = mouseState;
        }

        public void Execute()
        {
            Current.MouseState = mouseState;
        }
    }
}
