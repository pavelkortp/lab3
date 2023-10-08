namespace ConsoleApp1;

public class Tomato: Plant
{
    
    public Tomato(string fullName, int growingTime, bool isNeedRegrow, double landDepletion) :
        base("tomato", fullName, growingTime, isNeedRegrow, Season.ALL, landDepletion, true)
    {
        
    }

    public override bool IsHarvest()
    {
        return Seeds && GrowingTime <= 90;
    }
}