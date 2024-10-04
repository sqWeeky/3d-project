using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolB : Pool<Bomb>
{ 
    public override Bomb GetObject(Bomb prefab)
    {
        return base.GetObject(prefab);
    }

    public override void PutObject(Bomb prefab)
    {
        base.PutObject(prefab);
    }
}