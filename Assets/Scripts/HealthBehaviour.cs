using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;
    private float _health;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private UnityEvent _onDeath;

    public float Health { get => _health; private set => _health = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    public void Start()
    {
        _health = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            _onDeath?.Invoke();

            GameObject explosionInstance = Instantiate(_explosion, transform.position, _explosion.transform.rotation);

            ScreenShakeBehaviour.ShakeScreen();
            Destroy(explosionInstance, 1f);
            Destroy(gameObject);
        }
    }
}
