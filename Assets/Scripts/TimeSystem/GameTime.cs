using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public struct GameTime
{
    public int year;
    public int quad;
    public int day;
    public int hour;
    public int minute;

    public GameTime(int year, int quad, int day, int hour, int minute, int second)
    {
        this.year = year;
        this.quad = quad;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
    }

    public static bool operator ==(GameTime t1, GameTime t2)
    {
        return t1.year == t2.year &&
              t1.quad == t2.quad &&
              t1.day == t2.day &&
              t1.hour == t2.hour &&
               t1.minute == t2.minute;
    }

    public static bool operator !=(GameTime t1, GameTime t2)
    {
        return t1.year != t2.year ||
              t1.quad != t2.quad ||
              t1.day != t2.day ||
              t1.hour != t2.hour ||
               t1.minute != t2.minute;
    }



    public void AddOneDay()
    {
        day++;
        EventCenter.Instance.Trigger(EventName.DAY_CHANGE, this);
        if (day >= 30)
        {
            day = 1;
            quad++;
            EventCenter.Instance.Trigger(EventName.QUAD_CHANGE, this);
            if (quad >= 4)
            {
                quad = 1;
                year++;
                EventCenter.Instance.Trigger(EventName.YEAR_CHANGE, this);
                if (year >= 10000)
                {
                    year = 0;
                }
            }
        }
    }

    public void AddTick()
    {
        EventCenter.Instance.Trigger(EventName.GAME_TICK, this);
        minute++;
        EventCenter.Instance.Trigger(EventName.MINUTE_CHANGE, this);
        if (minute >= 60)
        {
            minute = 0;
            hour++;
            EventCenter.Instance.Trigger(EventName.HOUR_CHANGE, this);
            if (hour >= 24)
            {
                hour = 0;
                AddOneDay();
            }
        }
    }

    public override bool Equals(object obj)
    {
        return obj is GameTime time &&
               year == time.year &&
               quad == time.quad &&
               day == time.day &&
               hour == time.hour &&
               minute == time.minute;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}