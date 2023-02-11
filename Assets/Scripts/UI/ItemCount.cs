using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;
using UnityEngine.UI;

namespace LittleWorld.UI
{
    public class ItemCount : MonoBehaviour
    {
        public Text m_TextMeshPro;
        public Vector3 pos;

        public void BindData(int count, Vector3 followPos)
        {
            m_TextMeshPro.text = count.ToString();
        }

        private void LateUpdate()
        {
        }
    }
}
