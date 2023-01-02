using System;
using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;

namespace LittleWorldObject
{
    public class Brush : Plant, IOption
    {
        protected int fruitCount;
        protected int woodCount;

        public void OnInteraction()
        {
            var go = Instantiate(Resources.Load<GameObject>("Prefabs/UI/InteractionMenu/InteractionMenu"));
            go.name = go.name.Substring(0, go.name.LastIndexOf("(Clone)"));
            var menu = go.GetComponent<InteractionMenu>();
            go.transform.SetParent(GameObject.FindGameObjectWithTag("UICanvas")?.transform);
            go.transform.position = GameController.Instance.mousePosition;

            var contentList = new List<optionStruct>();
            contentList.Add(new optionStruct()
            {
                content = "砍树",
                OnClickOption = () =>
                {
                    Debug.Log("正在砍树！");
                }
            });
            contentList.Add(new optionStruct()
            {
                content = "摘取果实",
                OnClickOption = () =>
                {
                    Debug.Log("正在摘取果实！");
                }
            });

            menu.BindData(contentList);
        }

    }

    public struct OptionInfo
    {
        private string optionContent;
        private Action optionAction;
    }
}
