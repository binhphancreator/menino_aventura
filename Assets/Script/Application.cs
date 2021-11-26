using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application
{
    private Dictionary<string, object> instances;

    public Application()
    {
        instances = new Dictionary<string, object>();
    }

    public void singlethon(string key, object instance)
    {
        instances.Add(key, instance);
    }

    public T resolve<T>(string key)
    {
        if(!instances.ContainsKey(key)) throw new System.Exception("The instance is not exist");
        return (T) instances[key];
    }
}
