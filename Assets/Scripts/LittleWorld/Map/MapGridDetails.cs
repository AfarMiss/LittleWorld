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
