using LittleWorld.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LittleWorld.HealthTracer;

namespace LittleWorld.UI
{
    public class BriefInfoAnimalPanel : BriefInfoPanel
    {
        public override string Path => UIPath.Panel_BriefInfoAnimalPanel;
        [SerializeField] protected Slider hpSlider;
        [SerializeField] protected Slider hungerSlider;
        [SerializeField] protected Slider sleepSlider;
        [SerializeField] protected Text ageText;

        private Animal animalWatching;

        public override void BindBriefInfo(Item.Object o)
        {
            base.BindBriefInfo(o);
            if (o is Animal animal)
            {
                hpSlider.value = animal.HpPercent;
                hungerSlider.value = animal.HungerPercent;
                sleepSlider.value = animal.HungerPercent;
                UpdateAge(animal.Age);
                this.animalWatching = o as Animal; ;
            }
        }

        public void UpdateAge(Age age)
        {
            ageText.text = age.ToString();
        }

        protected override void OnEnable()
        {
            EventCenter.Instance.Register<Weapon>(EventName.UPDATE_WEAPON, OnWeaponChanged);
            EventCenter.Instance.Register<Age>(EventName.LIVING_AGE_DAY_CHANGE, OnDayChanged);
            EventCenter.Instance.Register<Age>(EventName.LIVING_AGE_YEAR_CHANGE, OnYearChanged);
        }

        private void OnYearChanged(Age arg0)
        {
            UpdateAge(arg0);
        }

        private void OnDayChanged(Age arg0)
        {
            throw new NotImplementedException();
        }

        protected override void OnDisable()
        {
            EventCenter.Instance?.Unregister<Weapon>(EventName.UPDATE_WEAPON, OnWeaponChanged);
            EventCenter.Instance?.Unregister<Age>(EventName.LIVING_AGE_DAY_CHANGE, OnDayChanged);
            EventCenter.Instance?.Unregister<Age>(EventName.LIVING_AGE_YEAR_CHANGE, OnYearChanged);
            animalWatching = null;
        }

        protected void OnWeaponChanged(Weapon weapon)
        {
            if (weapon.Owner.IsSelectedOnly)
            {
                BindBriefInfo(weapon.Owner);
            }
        }

    }
}
