using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public GameTime CurGameTime => curGameTime;
    private GameTime curGameTime;

    private float curTickTime;

    private TimeManager()
    {

    }

    public override void OnCreateInstance()
    {

        curTickTime = 0;
        curGameTime = new GameTime(6000, 1, 1, 6, 0, 0);
        EventCenter.Instance.Trigger(EventName.SECOND_CHANGE, curGameTime);
    }

    public override void Tick()
    {
        curTickTime += Time.fixedDeltaTime;
        while (curTickTime - GameSetting.TickTime > GameSetting.TickTime)
        {
            curTickTime -= GameSetting.TickTime;
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
