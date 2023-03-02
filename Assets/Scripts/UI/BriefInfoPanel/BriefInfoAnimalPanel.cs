using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LittleWorld.UI
{
    public class BriefInfoAnimalPanel : BriefInfoPanel
    {
        public override string Path => UIPath.Panel_BriefInfoAnimalPanel;
        [SerializeField] protected Slider hpSlider;
        [SerializeField] protected Slider hungerSlider;
        [SerializeField] protected Slider sleepSlider;
        [SerializeField] protected Text ageText;

        public override void BindBriefInfo(Item.Object o)
        {
            base.BindBriefInfo(o);
            if (o is Animal animal)
            {
                hpSlider.value = animal.HpPercent;
                hungerSlider.value = animal.HungerPercent;
                sleepSlider.value = animal.HungerPercent;
                ageText.text = animal.Age.ToString();
            }
        }

    }
}
