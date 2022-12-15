/// <summary>
/// 地图中每个格子的信息
/// </summary>
[System.Serializable]
public class GridPropertyDetails
{
    //坐标信息
    public int gridX;
    public int gridY;

    //坐标属性信息
    public bool isDiggable = false;
    public bool canDropItem = false;
    public bool canPlaceFurniture = false;
    public bool isPath = false;
    public bool isNPCObstacle = false;
    public int daysSinceDug = -1;
    public int daysSinceWatered = -1;
    public int seedItemCode = -1;
    public int growthDays = -1;
    public int daysSinceLastHarvest = -1;

    public GridPropertyDetails()
    {

    }

    public int GetCommodityCode()
    {
        switch (seedItemCode)
        {
            case 10006:
                return 10007;
            default:
                return -1;
        }
    }
}