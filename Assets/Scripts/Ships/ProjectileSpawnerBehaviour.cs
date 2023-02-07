using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private ProjectileBehaviour _projectile;
    [SerializeField]
    private float _projectileSpeed;
    [SerializeField]
    private LayerMask _collisionLayers;

    public LayerMask CollisionLayers { get => _collisionLayers; private set => _collisionLayers = value; }

    public void FireProjectile()
    {
        if (!_projectile)
            return;

        ProjectileBehaviour projectile = Instantiate(_projectile, transform.position, transform.rotation);

        projectile.CollisionLayers = _collisionLayers;

        Rigidbody projectileRigid = projectile.RB;

        projectileRigid.velocity = transform.up * _projectileSpeed;
    }
}
