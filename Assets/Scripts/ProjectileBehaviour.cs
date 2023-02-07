using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private LayerMask _collisionLayers;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _lifeTime;
    [SerializeField]
    private bool _destroyOnHit;
    [SerializeField]
    private GameObject _explosion;
    private Rigidbody _rigidbody;

    
    public Rigidbody RB { get => _rigidbody; private set => _rigidbody = value; }
    public LayerMask CollisionLayers { get => _collisionLayers; set => _collisionLayers = value; }

    // Start is called before the first frame update
    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        Destroy(gameObject, _lifeTime);
    }

    /// <summary>
    /// Checks if the layer is in the colliders layer mask of 
    /// layers to collide with.
    /// </summary>
    /// <param name="layer">The unity physics collision layer of the game object.</param>
    /// <returns></returns>
    public bool CheckCollisionWithLayer(int layer)
    {
        if (_collisionLayers == 0)
            return false;

        int mask = _collisionLayers;
        if (mask == (mask | 1 << layer))
            return true;

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!CheckCollisionWithLayer(other.gameObject.layer))
            return;

        HealthBehaviour health = other.GetComponent<HealthBehaviour>();
        health.TakeDamage(_damage);

        if (_destroyOnHit)
        {
            GameObject explosionInstance = Instantiate(_explosion, transform.position, _explosion.transform.rotation);

            explosionInstance.transform.localScale /= 2;

            Destroy(explosionInstance, 0.2f);
            Destroy(gameObject);
        }
    }
}
