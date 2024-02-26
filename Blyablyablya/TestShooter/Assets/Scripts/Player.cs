using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private PlayerShooting pShooting;

    private void Awake()
    {
        Instance = this;

        if(!pShooting)
            pShooting = GetComponent<PlayerShooting>();
    }

    private void Update()
    {
        pShooting.Shoot();
    }
}
