using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolC : Pool<Cube> 
{
    public override Cube GetObject(Cube prefab)
    {
        return base.GetObject(prefab);
    }

    public override void PutObject(Cube prefab)
    {
        base.PutObject(prefab);
    }
}