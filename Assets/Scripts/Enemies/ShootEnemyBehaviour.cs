using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyBehaviour : EnemyBehaviour
{
    [SerializeField]
    private ProjectileSpawnerBehaviour _projectileSpawner;
    [SerializeField]
    private float _shotDelay;
    private float _timeSinceLastShot;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _timeSinceLastShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _timeSinceLastShot >= _shotDelay)
        {
            _projectileSpawner.FireProjectile();
            _timeSinceLastShot = Time.time;
        }
    }
}
