using ProcedualWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class MapRenderManager : Singleton<MapRenderManager>
    {
        Dictionary<Map, MapRender> mapRenderers;
        public readonly string mapRenderPrefabString = "Prefabs/MapGrid";
        private GameObject mapPrefab;
        public GameObject MapsParent;

        public override void OnCreateInstance()
        {
            base.OnCreateInstance();
            mapRenderers = new Dictionary<Map, MapRender>();
            mapPrefab = Resources.Load<GameObject>(mapRenderPrefabString);
            MapsParent = new GameObject("MapsParent");
            GameObject.DontDestroyOnLoad(MapsParent);
        }

        private MapRenderManager()
        {

        }

        private MapRender AddMap(Map map)
        {
            if (!mapRenderers.TryGetValue(map, out var result))
            {
                var go = GameObject.Instantiate<GameObject>(mapPrefab, MapsParent.transform);
                var renderer = go.GetComponent<MapRender>();
                renderer.Init(map);
                mapRenderers.Add(map, renderer);

                return renderer;
            }
            return result;
        }

        public void RenderMap(Map map)
        {
            mapRenderers.TryGetValue(map, out var result);
            (result ?? AddMap(map)).RenderMap(map);
        }

        private void RemoveMap(Map map)
        {
            mapRenderers.Remove(map);
        }
    }
}
