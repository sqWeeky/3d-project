using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public Poolable enemyPrefab;
    public Poolable bulletPrefab;

    public int poolSize = 10;

    private List<Poolable> enemyPool;
    private List<Poolable> bulletPool;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        enemyPool = new List<Poolable>();
        bulletPool = new List<Poolable>();

        for (int i = 0; i < poolSize; i++)
        {
            Poolable enemy = Instantiate(enemyPrefab, transform);
            Poolable bullet = Instantiate(bulletPrefab, transform);

            enemy.gameObject.SetActive(false);
            bullet.gameObject.SetActive(false);

            enemyPool.Add(enemy);
            bulletPool.Add(bullet);
        }
    }

    public Poolable GetEnemyFromPool()
    {
        foreach (Poolable enemy in enemyPool)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                enemy.gameObject.SetActive(true);
                enemyPool.Remove(enemy);
                enemy.OnGet();
                return enemy;
            }
        }

        Poolable newEnemy = Instantiate(enemyPrefab, transform);
        enemyPool.Add(newEnemy);
        newEnemy.OnGet();
        return newEnemy;
    }

    public Poolable GetBulletFromPool()
    {
        foreach (Poolable bullet in bulletPool)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                bullet.gameObject.SetActive(true);
                bulletPool.Remove(bullet);
                bullet.OnGet();
                return bullet;
            }
        }

        Poolable newBullet = Instantiate(bulletPrefab, transform);
        bulletPool.Add(newBullet);
        newBullet.OnGet();
        return newBullet;
    }

    public void ReturnEnemyToPool(Poolable enemy)
    {
        enemy.OnReturn();
        enemyPool.Add(enemy);
        enemy.transform.parent = transform;
        enemy.gameObject.SetActive(false);
    }

    public void ReturnBulletToPool(Poolable bullet)
    {
        bullet.OnReturn();
        bulletPool.Add(bullet);
        bullet.transform.parent = transform;
        bullet.gameObject.SetActive(false);
    }
}