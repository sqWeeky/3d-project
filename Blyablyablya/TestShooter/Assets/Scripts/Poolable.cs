using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour, IPoolable
{
    public virtual void OnGet()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnReturn()
    {
        throw new System.NotImplementedException();
    }
}
