namespace ConsoleApp1;

public class Carrot : Plant
{
    private double _weight;
    public Carrot(string fullName, int growingTime, bool isNeedRegrow, Season growingSeason, double landDepletion,
        double weight) :
        base("carrot", fullName, growingTime, isNeedRegrow, growingSeason, landDepletion, false)
    {
        _weight = weight;
        if (weight > 1)
        {
            LandDepletion = LandDepletion / weight + LandDepletion;
        }
    }

    public override bool IsHarvest()
    {
        return !Seeds && GetCurrentSeason() == GrowingSeason && LandDepletion <= MaxLandDepletion / 2;
    }
    
}