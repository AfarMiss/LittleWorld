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
            Debug.Log($"命令:{command.GetType().Name}进队！");
        }

        public void Dequeue()
        {
            var command = commands.Dequeue();
            Debug.Log($"命令:{command.GetType().Name}出队！");
        }

        public override void Tick()
        {
            base.Tick();
            if (commands.TryDequeue(out ICommand command))
            {
                command.Execute();
                Debug.Log($"命令:{command.GetType().Name}执行！");
            }
        }
    }
}
