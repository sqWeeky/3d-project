using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : Poolable
{
    [SerializeField] private float speed;

    private bool isActive;
    public float Speed => speed;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;

        if (other.gameObject.CompareTag("Obstacle"))
        {
            ObjectPool.Instance.ReturnBulletToPool(this);
            return;
        }

        if (other.gameObject.CompareTag("Player"))
            return;

        if (other.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.SetDamage(Constants.Bullets.FirstWeaponDamage);
            ObjectPool.Instance.ReturnBulletToPool(this);
        }
    }

    public override void OnGet()
    {
        isActive = true;
    }

    public override void OnReturn()
    {
        isActive = false;
    }
}
