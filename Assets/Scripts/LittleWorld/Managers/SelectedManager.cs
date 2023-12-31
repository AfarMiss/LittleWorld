﻿using LittleWorld.Extension;
using LittleWorld.Interface;
using LittleWorld.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleWorld
{
    public enum SelectType
    {
        /// <summary>
        /// 按物体优先级选择
        /// </summary>
        REGION_TOP,
        /// <summary>
        /// 同类
        /// </summary>
        SAME_TYPE,
    }

    public enum SelectLayer
    {
        ALL = 0,
        HUMAN = 1,
        ANIMAL = 2,
        ITEM = 3,
        OTHER = 4
    }
    public class SelectedManager : Singleton<SelectedManager>
    {

    }

    public static class SelectUtility
    {

        public static bool MultiPawnSelected(this List<WorldObject> selectedObjects)
        {
            return selectedObjects != null
    && selectedObjects.Count > 1
    && selectedObjects.Find(x => x as Humanbeing == null) == null;
        }

        public static bool SinglePawnSelected(this List<WorldObject> selectedObjects)
        {
            return selectedObjects.Count == 1
        && selectedObjects.Find(x => x as Humanbeing == null) == null;
        }

        public static bool NoSelected(this List<WorldObject> selectedObjects)
        {
            return selectedObjects == null || selectedObjects.Count == 0;
        }

        public static bool NonHumanSelected(this List<WorldObject> selectedObjects)
        {
            return selectedObjects.Count == 0
            || selectedObjects.Find(x => x as Humanbeing == null) != null;
        }

        public static bool MultiTypeSelected(this List<WorldObject> selectedObjects)
        {
            if (selectedObjects == null || selectedObjects.Count == 0)
            {
                return false;
            }

            var typeHashSet = new HashSet<Type>();
            foreach (var item in selectedObjects)
            {
                if (typeHashSet.Contains(item.GetType()))
                {
                    continue;
                }
                else
                {
                    if (typeHashSet.Count == 0)
                    {
                        typeHashSet.Add(item.GetType());
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return typeHashSet.Count > 1;
        }

        public static void Select(this IEnumerable<Item.Object> objects)
        {
            foreach (var item in objects)
            {
                if (item is ISelectable selectable)
                {
                    selectable.OnSelect();
                }
            }
        }

        public static void Unselect(this IEnumerable<Item.Object> objects)
        {
            foreach (var item in objects)
            {
                if (item is ISelectable selectable)
                {
                    selectable.OnUnselect();
                }
            }
        }

        public static List<WorldObject> GetSelected(this List<WorldObject> selectedObjects,
            SelectType selectType = SelectType.REGION_TOP, WorldObject objectRef = null)
        {
            if (selectedObjects == null || selectedObjects.Count == 0)
            {
                return null;
            }
            List<WorldObject> humans = selectedObjects.FindAll(x => x is Humanbeing);
            var animals = selectedObjects.FindAll(x => x is Animal && !(x is Humanbeing));
            var plants = selectedObjects.FindAll(x => x is Plant);
            var others = selectedObjects.FindAll(x => !(x is Plant) && !(x is Animal));
            switch (selectType)
            {
                case SelectType.REGION_TOP:
                    if (humans.Safe().Any())
                    {
                        Select(humans);
                        return humans;
                    }
                    if (animals.Safe().Any())
                    {
                        Select(animals);
                        return animals;
                    }
                    if (plants.Safe().Any())
                    {
                        Select(plants);
                        return plants;
                    }
                    if (others.Safe().Any())
                    {
                        Select(others);
                        return others;
                    }
                    break;
                case SelectType.SAME_TYPE:
                    if (objectRef == null)
                    {
                        return null;
                    }
                    var sameTypes = selectedObjects.FindAll(x => x.GetType() == objectRef.GetType());
                    Select(sameTypes);
                    return sameTypes;
                default:
                    return null;
            }
            return null;

        }

    }
}
