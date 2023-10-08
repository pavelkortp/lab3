namespace ConsoleApp1;

public class Farm
{
    private const int DefaultLimit = 20;
    private int _plantsLimit;
    private Farmer? _farmer;
    public string Name { get; set; }
    public int PlantsLimit
    {
        get => _plantsLimit;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentException("Limit time must be >0 !");
            }

            _plantsLimit = value;
        }
    }

    public List<Plant> PlantsOnGrowing { get; }

    public Farmer? Farmer
    {
        get =>_farmer;
        private set
        {
            if (value == null)
            {
                throw new ArgumentException("Farmer must be not null!");
            }
            _farmer = value;
        }
    }

    public Farm() : this("Farm")
    {
    }

    public Farm(string name, int limit = DefaultLimit) : this(name, limit, null)
    {
    }

    public Farm(string name, int limit, Farmer? farmer)
    {
        Name = name;
        PlantsLimit = limit;
        PlantsOnGrowing = new List<Plant>(limit);
        Farmer = farmer;
    }

    /// <summary>
    /// Adds plant to list PlantsOnGrowing.
    /// </summary>
    /// <param name="plant">Plant which need to be add.</param>
    /// <returns>True if plant successfully added or False if list are full.</returns>
    public bool AddPlant(Plant plant)
    {
        if (PlantsOnGrowing.Count == PlantsLimit)
        {
            return false;
        }

        PlantsOnGrowing.Add(plant);
        return true;
    }

    /// <summary>
    /// Finds a plant in PlantsOnGrowing by name.
    /// </summary>
    /// <param name="name"> Plant name</param>
    /// <returns>Searched plant or null if it absent.</returns>
    public Plant? FindByPlantName(string name)
    {
        return PlantsOnGrowing.Find(p => p.ShortName == name || p.FullName == name);
    }

    /// <summary>
    /// Removes plant from list.
    /// </summary>
    /// <param name="plant">Plant which need to be removed.</param>
    /// <returns>True if plant successfully removed, otherwise False.</returns>
    public bool DeletePlant(Plant plant)
    {
        return PlantsOnGrowing.Remove(plant);
    }

    /// <summary>
    /// Changes current farmer on new.
    /// </summary>
    /// <param name="farmer">New farmer.</param>
    public void SetNewFarmer(Farmer farmer)
    {
        Farmer = farmer;
    }
}