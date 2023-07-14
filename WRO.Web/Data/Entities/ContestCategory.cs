namespace WRO.Web.Data.Entities;

public class ContestCategory : Entity
{
    public ContestCategory() { }

    public ContestCategory(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = string.Empty;
}
