namespace Faker;

public class GeneratorContext
{
    public Random Random { get; }
    public Dictionary<Type, object> KnownInstances = new();

    public object GetGeneratedInstance(Type type)
    {
        return KnownInstances.ContainsKey(type) ? KnownInstances[type] : null;
    }

    public void StoreGeneratedInstance(Type type, object target)
    {
        KnownInstances.Add(type, target);
    }
    
    public GeneratorContext()
    {
        Random = new Random();
    }
}