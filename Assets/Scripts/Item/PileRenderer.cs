using LittleWorld.Extension;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using UnityEngine;

namespace LittleWorld.Item
{
    public class PileRenderer : MonoBehaviour
    {
        [SerializeField, ItemCodeDescription]
        private int itemCode;

        private SpriteRenderer spriteRenderer;

        public int ItemCode { get { return itemCode; } set { itemCode = value; } }

        public void Render(int pileCode, Vector2Int destination, Map map)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            map.GetGrid(destination, out var gridResult);
            spriteRenderer.enabled = gridResult.HasPiledThing;
            if (!spriteRenderer.enabled)
            {
                return;
            }
            spriteRenderer.sprite = ObjectConfig.ObjectInfoDic[pileCode].defaultSprite;
            Set(destination);

            this.ItemCode = pileCode;
        }

        private void Set(Vector2Int destination)
        {
            spriteRenderer.transform.localScale = Vector3.one;
            spriteRenderer.transform.localPosition = new Vector3(
                spriteRenderer.sprite.pivot.x / spriteRenderer.sprite.pixelsPerUnit,
                spriteRenderer.sprite.pivot.y / spriteRenderer.sprite.pixelsPerUnit,
                0);
            this.transform.position = destination.To3();
        }
    }

}