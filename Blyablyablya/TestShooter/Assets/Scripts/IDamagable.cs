using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public void SetDamage(int damage = 1);

    public void Kill();
}
