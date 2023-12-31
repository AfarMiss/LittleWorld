﻿using LittleWorld.Item;
using UnityEngine;
using UnityEngine.UI;
using static LittleWorld.HealthTracer;
using static LittleWorld.Item.Bullet;

namespace LittleWorld.UI
{
    public class BriefInfoAnimalPanel : BriefInfoPanel
    {
        public override string Path => UIPath.Panel_BriefInfoAnimalPanel;
        [SerializeField] protected Slider hpSlider;
        [SerializeField] protected Slider hungerSlider;
        [SerializeField] protected Slider sleepSlider;
        [SerializeField] protected Slider thirstySlider;
        [SerializeField] protected Text ageText;
        [SerializeField] protected Text posText;
        [SerializeField] protected Text actionText;
        [SerializeField] protected Text leftNutritionText;

        private Animal animalWatching;

        public override void BindSingleItem(Item.Object o)
        {
            base.BindSingleItem(o);
            if (o is Animal animal)
            {
                BindData(animal);
                this.animalWatching = o as Animal;
            }
        }

        public void UpdateBriefInfo(Item.Object o)
        {
            if (animalWatching == o as Animal)
            {
                //应使用按钮的灰暗/明亮而不是消失/显示来更新可用命令，下次修改按钮的生成逻辑。
                base.BindTitle(o);
                if (o is Animal animal)
                {
                    BindData(animal);
                }
            }
        }

        private void BindData(Animal animal)
        {
            hpSlider.value = animal.HpPercent;
            hungerSlider.value = animal.HungerPercent;
            sleepSlider.value = animal.SleepPercent;
            thirstySlider.value = animal.ThirstyPercent;
            UpdateAge(animal.Age);
            this.posText.text = animal.GridPos.ToString();
            this.actionText.text = animal.curToilName;
            this.leftNutritionText.text = animal.leftNutrition.ToString("f2");
        }

        public void UpdateAge(Age age)
        {
            ageText.text = age.ToString();
        }

        protected override void OnEnable()
        {
            this.EventRegister<Weapon>(EventName.UPDATE_WEAPON, OnWeaponChanged);
            this.EventRegister<Age>(EventName.LIVING_AGE_DAY_CHANGE, OnDayChanged);
            this.EventRegister<Age>(EventName.LIVING_AGE_YEAR_CHANGE, OnYearChanged);
            this.EventRegister<DamageInfo>(EventName.LIVING_BE_HURT, OnLivingBeHurt);
            this.EventRegister<Animal>(EventName.UPDATE_LIVING_STATE, UpdateBriefInfo);
        }

        private void OnLivingBeHurt(DamageInfo arg0)
        {
            if (animalWatching == arg0.target)
            {
                this.hpSlider.value = arg0.target.HpPercent;
            }
        }

        private void OnYearChanged(Age arg0)
        {
            UpdateAge(arg0);
        }

        private void OnDayChanged(Age arg0)
        {
            UpdateAge(arg0);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            animalWatching = null;
        }

        protected void OnWeaponChanged(Weapon weapon)
        {
            if (weapon.Owner.IsSelectedOnly)
            {
                BindSingleItem(weapon.Owner);
            }
        }

    }
}
