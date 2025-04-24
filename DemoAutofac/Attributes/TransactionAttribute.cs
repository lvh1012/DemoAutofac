namespace DemoAutofac.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class TransactionAttribute : Attribute
{
    public TransactionAttribute()
    {
    }
}