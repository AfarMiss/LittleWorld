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
        public Dictionary<int, int> curBuildingContain;

        public bool isLand => gridAltitudeLayer >= 20;

        public bool isPlane => gridAltitudeLayer >= 30 && gridAltitudeLayer < 75;
        public bool isMountain => gridAltitudeLayer >= 75 && gridAltitudeLayer <= 100;
        public bool HasPlant
        {
            get
            {
                var objects = WorldUtility.GetObjectsAtCell(pos.To3());
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

        public void ClearBuildingMaterials()
        {
            curBuildingContain.Clear();
        }

        public bool isFull => piledThingCode != -1 && ObjectConfig.ObjectInfoDic[piledThingCode].CanPile && ObjectConfig.ObjectInfoDic[piledThingCode].maxPileCount <= piledAmount;

        private int piledAmount = 0;
        public bool HasPiledThing => hasPiledThing;

        private bool hasPiledThing = false;

        public int PiledAmount => piledAmount;

        public bool AddSinglePiledWorldObject(WorldObject wo)
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

        public bool AddSingleBlueprintWorldObject(WorldObject wo)
        {
            if (!wo.canPile)
            {
                wo.GridPos = pos;
                return true;
            }
            else
            {
                return AddBlueprintThing(wo);
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

        private bool AddBlueprintThing(WorldObject wo)
        {
            if (curBuildingContain.ContainsKey(wo.itemCode))
            {
                curBuildingContain[wo.itemCode]++;
            }
            else
            {
                curBuildingContain.Add(wo.itemCode, 1);
            }
            wo.GridPos = pos;
            return true;
        }


        public bool DeleteSinglePiledThing()
        {
            piledAmount--;
            var objects = WorldUtility.GetObjectsAtCell(pos.To3());
            if (objects != null)
            {
                var result = objects.ToList().Find(x =>
                (ObjectConfig.ObjectInfoDic[x.itemCode].CanPile));
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
            wo.GridPos = VectorExtension.undefinedV2Int;
            wo.carriedParent = hauler;
            piledAmount--;

            var objects = WorldUtility.GetObjectsAtCell(pos.To3());
            if (objects != null)
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
            var objects = WorldUtility.GetObjectsAtCell(pos.To3());
            var wo = objects.ToList().Find(x => x.itemCode == itemCode
            && x is WorldObject realWo
            && !realWo.isCarried);
            if (wo == null)
            {
                woPickUp = null;
                return false;
            }
            else
            {
                var realWo = wo as WorldObject;
                realWo.isCarried = true;
                realWo.carriedParent = hauler;
                piledAmount--;

                if (objects != null)
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
                var objects = WorldUtility.GetObjectsAtCell(pos.To3());
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
                var objects = WorldUtility.GetObjectsAtCell(pos.To3());
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
            curBuildingContain = new Dictionary<int, int>();
        }
    }
}
