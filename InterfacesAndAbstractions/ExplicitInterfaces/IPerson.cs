namespace ExplicitInterfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        string Age { get; set; }

        string GetName();
    }
}
