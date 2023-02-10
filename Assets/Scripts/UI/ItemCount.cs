using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LittleWorld.UI
{
    public class ItemCount : MonoBehaviour
    {
        public TMPro.TextMeshPro m_TextMeshPro;

        public void BindData(int count)
        {
            m_TextMeshPro.text = count.ToString();
        }
    }
}
