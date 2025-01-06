using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YourNamespace;

public class RandomDataMaker<T> where T : class, new()
{
    private Random random = new Random();
    public List<T> list { get; set; }
    public RandomDataMaker(int repaet,IList<object> ranges)
    {
        var a = typeof(T).GetProperties().ToList();
        list=RandomData(a, repaet,ranges);
    }

    public List<T> RandomData(List<PropertyInfo> propertyInfos, int repaet, IList<object> ranges)
    {
        var listOfClass = new List<T>();
        var count = 0;
        foreach (var num in Enumerable.Range(1, repaet))
        {
            var newClassInstance = new T();
            for (int i=0;i<propertyInfos.Count;i++)
            {
                if (propertyInfos[i].PropertyType == typeof(string))
                {
                    var a = ranges[i] as string[];
                    propertyInfos[i].SetValue(newClassInstance, a[random.Next(0, a.Length )]);
                }
                else if (propertyInfos[i].PropertyType == typeof(float))
                {
                    var a = ranges[i] as int[];
                    propertyInfos[i].SetValue(newClassInstance, (float)random.Next(a[0], a[1]));
                }
            }
            listOfClass.Add(newClassInstance);
        }
        return listOfClass;
    }
}
