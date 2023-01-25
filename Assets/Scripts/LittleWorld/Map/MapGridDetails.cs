using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class MapGridDetails
    {
        public Vector2Int pos;
        public int gridAltitudeLayer;
        public Rect gridRect;

        public MapGridDetails(Vector2Int pos, int gridAltitudeLayer)
        {
            this.pos = pos;
            this.gridAltitudeLayer = gridAltitudeLayer;
            gridRect = new Rect(pos, Vector2.one);
        }
    }
}
