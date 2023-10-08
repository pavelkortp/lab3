namespace ConsoleApp1;

public abstract class Plant
{
    /* When plants grow, they deplete the soil, absorbing nutrients, water,
     * minerals, acids, and so on. Each plant absorbs substances differently
     * during its growth period. At most, the land can give away conditional
     * 100% of the substances, which is equal to 1.0
     */
    protected const double MaxLandDepletion = 1.0;

    /* What percentage of the land is depleted by a particular plant (0.7 => 70%) */
    private double _landDepletion;

    public double LandDepletion
    {
        get => _landDepletion;
        set
        {
            if (value > 1 || value <= 0)
            {
                throw new ArgumentException("Lend deplection must be between 0 and 1!");
            }

            _landDepletion = value;
        }
    }

    private int _growingTime;
    private bool _seeds;

    public bool Seeds
    {
        get => _seeds;
        set => _seeds = value;
    }

    private Season _growingSeason;

    public Season GrowingSeason
    {
        get => _growingSeason;
        set => _growingSeason = value;
    }

    public string ShortName { get; }
    public string FullName { get; }

    public int GrowingTime
    {
        get => _growingTime;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentException("Growing time must be >0 !");
            }

            _growingTime = value;
        }
    }

    public bool IsNeedRegrow { get; init; }

    protected Plant(string shortName, string fullName, int growingTime, bool isNeedRegrow, Season growingSeason,
        double landDepletion, bool seeds)
    {
        ShortName = shortName;
        FullName = fullName;
        GrowingTime = growingTime;
        IsNeedRegrow = isNeedRegrow;
        _growingSeason = growingSeason;
        _landDepletion = landDepletion;
        _seeds = seeds;
    }

    /// <summary>
    /// Checks whether the plant can produce a crop.
    /// </summary>
    /// <returns>true if yes, otherwise false</returns>
    public virtual bool IsHarvest()
    {
        return GetCurrentSeason() == _growingSeason && _seeds && _landDepletion <= MaxLandDepletion / 2;
    }

    /// <summary>
    /// Determines the current season and returns it.
    /// </summary>
    /// <returns>Current season</returns>
    protected Season GetCurrentSeason()
    {
        switch (DateTime.Now.Month)
        {
            case 1:
            case 2:
            case 12:
                return Season.WINTER;
            case 3:
            case 4:
            case 5:
                return Season.SPRING;
            case 6:
            case 7:
            case 8:
                return Season.SUMMER;
            default:
                return Season.OUTUMN;
        }
    }

    public override string ToString()
    {
        return "full name: " + FullName + "\n" +
               "growing Time: " + _growingTime + "\n" +
               "growing Season: " + _growingSeason + "\n" +
               "Land depletion: " + LandDepletion;
    }
}

/// <summary>
/// Enum with seasons names.
/// </summary>
public enum Season
{
    SUMMER,
    OUTUMN,
    WINTER,
    SPRING,
    ALL
}