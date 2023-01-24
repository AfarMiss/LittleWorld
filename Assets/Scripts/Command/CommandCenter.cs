using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Command
{
    public class CommandCenter : Singleton<CommandCenter>
    {
        Queue<ICommand> commands = new Queue<ICommand>();

        private CommandCenter()
        {
        }

        public void Enqueue(ICommand command)
        {
            commands.Enqueue(command);
        }

        public void Dequeue()
        {
            commands.Dequeue();
        }

        public override void Tick()
        {
            base.Tick();
            if (commands.TryDequeue(out ICommand command))
            {
                command.Execute();
            }
        }
    }
}
