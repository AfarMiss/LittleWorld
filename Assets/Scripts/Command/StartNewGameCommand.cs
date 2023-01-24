using LittleWorld.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Command
{
    public class StartNewGameCommand : ICommand
    {
        public void Execute()
        {
            UIManager.Instance.ShowPanel<StartNewGamePanel>();
            Root.Instance.CurGame = new Game();
            Root.Instance.GameState = GameState.PREPARING;
        }
    }
}
