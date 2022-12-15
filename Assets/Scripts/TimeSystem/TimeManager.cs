using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{
    private GameTime curGameTime;

    private float curTickTime;

    public void Init()
    {
        curTickTime = 0;
        curGameTime = new GameTime(6000, 1, 1, 6, 0, 0);
        EventCenter.Instance.Trigger(EventEnum.SECOND_CHANGE.ToString(), curGameTime);
    }

    private void FixedUpdate()
    {
        curTickTime += Time.fixedDeltaTime;
        while (curTickTime - FarmSetting.gameTick > FarmSetting.gameTick)
        {
            curTickTime -= FarmSetting.gameTick;
            curGameTime.AddTick();
        }
    }

    public void AdvanceDay()
    {
        curGameTime.AddOneDay();
    }

    public void AdvanceDay(int count)
    {
        for (int i = 0; i < count; i++)
        {
            curGameTime.AddOneDay();
        }
    }
}
