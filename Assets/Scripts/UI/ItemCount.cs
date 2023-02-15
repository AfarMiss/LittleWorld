using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;
using UnityEngine.UI;

namespace LittleWorld.UI
{
    public class ItemCount : MonoBehaviour
    {
        public Text UIText;
        private Vector2Int pos;

        public void BindData(int count, Vector2Int pos)
        {
            UIText.text = count.ToString();
            this.pos = pos;
        }

        private void OnEnable()
        {
            Debug.Log("On Enable:" + this.pos);
        }

        private void OnDisable()
        {
            Debug.Log("On Disable:" + this.pos);
        }
    }
}
