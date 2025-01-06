using System.Linq.Expressions;
using System.Reflection;

namespace UI;

public class FluentBuilder<T> where T : class, new()
{
    readonly T _instance;
    public FluentBuilder()
    {
        _instance = new T();
    }

    public FluentBuilder<T> WithProperty<TProperty>(Expression<Func<T, TProperty>> propertyExpression, TProperty value)
    {
        var property = (PropertyInfo)((MemberExpression)propertyExpression.Body).Member;
        property.SetValue(_instance, value);
        return this;
    }

    public T Create() => _instance;

    public void Print()
    {
        typeof(T).GetProperties().ToList().ForEach(p => Console.WriteLine($"{p.Name}: {p.GetValue(_instance)}"));
    }
}
