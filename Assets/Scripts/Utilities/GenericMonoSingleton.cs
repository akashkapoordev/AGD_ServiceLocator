using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
{
    public static T Instance { get { return instance; } }

    private static T instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogWarning("There is already an instance of " + typeof(T) + " in the scene");
            Destroy(this.gameObject);
        }
    }
}
