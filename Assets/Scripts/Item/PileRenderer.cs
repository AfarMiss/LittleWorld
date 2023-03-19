using LittleWorld.Extension;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using UnityEngine;

namespace LittleWorld.Item
{
    public class PileRenderer : MonoBehaviour, IRenderer
    {
        public int pileCode;
        public Map belongTo;
        [SerializeField, ItemCodeDescription]
        private int itemCode;

        private SpriteRenderer spriteRenderer;

        public void Init(int pileCode, Map belongTo)
        {
            this.pileCode = pileCode;
            this.belongTo = belongTo;
        }

        public int ItemCode { get { return itemCode; } set { itemCode = value; } }

        private void Start()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void Render(int pileCode, Vector2Int destination, Map map)
        {
            if (spriteRenderer == null)
            {
                return;
            }
            if (destination == VectorExtension.undefinedV2Int)
            {
                spriteRenderer.enabled = false;
                return;
            }
            spriteRenderer.enabled = map.GetGrid(destination).HasPiledThing;
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

        public void OnRender()
        {
            throw new System.NotImplementedException();
        }
    }

}