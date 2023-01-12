using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using UnityEngine;

namespace LittleWorld.Window
{
    public static class FloatMenuMaker
    {
        public static optionStruct[] MakeFloatMenuAt(Vector3 mousePos)
        {
            var go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/InteractionMenu/InteractionMenu"));
            go.name = go.name.Substring(0, go.name.LastIndexOf("(Clone)"));
            var menu = go.GetComponent<InteractionMenu>();
            go.transform.SetParent(GameObject.FindGameObjectWithTag("UICanvas")?.transform);
            go.transform.position = InputController.Instance.mousePosition;

            var contentList = new List<optionStruct>();

            var worldObjects = WorldUtility.GetWorldObjectsAt(mousePos.GetWorldPosition());

            foreach (var worldObject in worldObjects)
            {
                contentList.AddRange(worldObject.AddFloatMenu());
            }

            menu.BindData(contentList);
            return contentList.ToArray();
        }
    }
}
