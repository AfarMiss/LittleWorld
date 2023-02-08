using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LittleWorld.Command.ChangeMouseStateCommand;

namespace LittleWorld.Command
{
    public class ChangeMouseStateCommand : ICommand
    {
        private MouseState mouseState;
        private Handler handler;
        public delegate void Handler(object param);
        public ChangeMouseStateCommand(MouseState mouseState, Handler handler = null)
        {
            this.mouseState = mouseState;
        }

        public void Execute()
        {
            Current.MouseState = mouseState;
        }
    }
}
