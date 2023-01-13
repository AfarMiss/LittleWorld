using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Interface
{
    public interface IObserveSceneChange
    {
        public void ObserveChangeSceneRegister();
        public void AfterSceneLoad();
        public void BeforeSceneUnload();
        public void ObserveChangeSceneUnregister();
    }
}
