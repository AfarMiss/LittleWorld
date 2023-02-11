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

        public void BindData(int count)
        {
            UIText.text = count.ToString();
        }
    }
}
