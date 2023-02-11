using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class MapGridDetails
    {
        public Vector2Int pos;
        public int gridAltitudeLayer;
        public Rect gridRect;
        public bool isPlantZone;
        public bool isLand => gridAltitudeLayer >= 30;

        public bool isPlane => gridAltitudeLayer >= 30 && gridAltitudeLayer < 75;
        public bool isMountain => gridAltitudeLayer >= 75 && gridAltitudeLayer <= 100;
        public bool HasPlant
        {
            get
            {
                var objects = WorldUtility.GetWorldObjectsAt(pos.To3());
                if (objects != null)
                {
                    var result = objects.ToList().Find(x => (x is Plant));
                    return result != null;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool isFull
        {
            get
            {
                var objects = WorldUtility.GetWorldObjectsAt(pos.To3());
                if (objects != null && objects.Length > 0)
                {
                    var result = objects.ToList().Find(x =>
                    (ObjectConfig.ObjectInfoDic[x.itemCode].canPile
                    && ObjectConfig.ObjectInfoDic[x.itemCode].maxPileCount <= CurPiled));
                    return result != null;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool HasPiledThing => hasPiledThing;

        private bool hasPiledThing = false;

        public Item.Object PiledThing
        {
            get
            {
                var objects = WorldUtility.GetWorldObjectsAt(pos.To3());
                if (objects != null && objects.Length > 0)
                {
                    var result = objects.ToList().Find(x =>
                    (ObjectConfig.ObjectInfoDic[x.itemCode].canPile));
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public int PiledThingLength
        {
            get
            {
                if (WorldUtility.GetWorldObjectsAt(pos.To3()) != null && WorldUtility.GetWorldObjectsAt(pos.To3()).Length > 0)
                {
                    var result = WorldUtility.GetWorldObjectsAt(pos.To3()).ToList().FindAll(x =>
                    (ObjectConfig.ObjectInfoDic[x.itemCode].canPile));
                    return result.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool AddSingleWorldObject(WorldObject wo)
        {
            if (!isFull)
            {
                wo.GridPos = pos;
                if (wo.canPile)
                {
                    hasPiledThing = true;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveSingleWorldObject(WorldObject wo)
        {
            wo.Destroy();
            var objects = WorldUtility.GetWorldObjectsAt(pos.To3());
            if (objects != null && objects.Length > 0)
            {
                var result = objects.ToList().Find(x =>
                (ObjectConfig.ObjectInfoDic[x.itemCode].canPile));
                hasPiledThing = result != null;
            }
            else
            {
                hasPiledThing = false;
            }
            return true;
        }

        public int CurPiled
        {
            get
            {
                var allPiledObjects = SceneObjectManager.Instance.WorldObjects.Values.ToList().FindAll(x => x.GridPos == pos && x.canPile);
                return allPiledObjects == null ? 0 : allPiledObjects.Count;
            }
        }

        public Plant Plant
        {
            get
            {
                var objects = WorldUtility.GetWorldObjectsAt(pos.To3());
                if (objects != null)
                {
                    var result = objects.ToList().Find(x => (x is Plant));
                    return result as Plant;
                }
                return null;
            }
        }
        public int PlantCode
        {
            get
            {
                var objects = WorldUtility.GetWorldObjectsAt(pos.To3());
                if (objects != null)
                {
                    var result = objects.ToList().Find(x => x is Plant);
                    if (result is Plant plant)
                    {
                        return plant.itemCode;
                    }
                    return -1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public MapGridDetails(Vector2Int pos, int gridAltitudeLayer)
        {
            this.pos = pos;
            this.gridAltitudeLayer = gridAltitudeLayer;
            gridRect = new Rect(pos, Vector2.one);
        }
    }
}
