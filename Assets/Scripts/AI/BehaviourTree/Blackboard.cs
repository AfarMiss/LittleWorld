using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

namespace AI
{
    /// <summary>
    /// 节点共用变量容器，被NodeGraph持有
    /// </summary>
    public class Blackboard
    {
        private Dictionary<string, object> dataContext;

        public void SetVariable(string key, object value)
        {
            dataContext[key] = value;
        }

        public object GetVariable(string key)
        {
            if (dataContext.TryGetValue(key, out object value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public Blackboard()
        {
            dataContext = new Dictionary<string, object>();
        }
    }
}
