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
        private int piledThingCode = -1;
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

        public bool isFull => piledThingCode != -1 && ObjectConfig.ObjectInfoDic[piledThingCode].canPile && ObjectConfig.ObjectInfoDic[piledThingCode].maxPileCount <= piledAmount;

        private int piledAmount = 0;
        public bool HasPiledThing => hasPiledThing;

        private bool hasPiledThing = false;

        public int PiledAmount => piledAmount;

        public bool AddSingleWorldObject(WorldObject wo)
        {
            if (!wo.canPile)
            {
                wo.GridPos = pos;
                return true;
            }
            else
            {
                return AddPileThing(wo);
            }
        }

        private bool AddPileThing(WorldObject wo)
        {
            if (!isFull)
            {
                if (hasPiledThing)
                {
                    if (wo.itemCode != piledThingCode)
                    {
                        return false;
                    }
                    else
                    {
                        wo.GridPos = pos;
                        piledAmount++;
                        return true;
                    }
                }
                else
                {
                    hasPiledThing = true;
                    wo.GridPos = pos;
                    piledAmount++;
                    piledThingCode = wo.itemCode;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool DeleteSinglePiledThing()
        {
            piledAmount--;
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

        public bool PickUp(WorldObject wo, WorldObject hauler)
        {
            wo.isCarried = true;
            wo.carriedParent = hauler;
            piledAmount--;

            var objects = WorldUtility.GetWorldObjectsAt(pos.To3());
            if (objects != null && objects.Length > 0)
            {
                var result = objects.ToList().Find(x =>
                 (x is WorldObject) && (x as WorldObject).canPile && !(x as WorldObject).isCarried);
                hasPiledThing = result != null;
            }
            else
            {
                hasPiledThing = false;
            }
            return true;
        }

        public bool PickUp(int itemCode, WorldObject hauler, out WorldObject woPickUp)
        {
            var objects = WorldUtility.GetWorldObjectsAt(pos.To3());
            var wo = objects.ToList().Find(x => x.itemCode == itemCode);
            if (wo is not WorldObject realWo)
            {
                woPickUp = null;
                return false;
            }
            else
            {
                realWo.isCarried = true;
                realWo.carriedParent = hauler;
                piledAmount--;

                if (objects != null && objects.Length > 0)
                {
                    var result = objects.ToList().Find(x =>
                     (x is WorldObject) && (x as WorldObject).canPile && !(x as WorldObject).isCarried);
                    hasPiledThing = result != null;
                }
                else
                {
                    hasPiledThing = false;
                }
                woPickUp = wo as WorldObject;
                return true;
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
