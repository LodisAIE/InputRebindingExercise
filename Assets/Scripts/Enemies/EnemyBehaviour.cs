using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _damage;

    protected virtual void Start()
    {
        GetComponent<HealthBehaviour>().OnDeath.AddListener(() => GameManagerBehaviour.Instance.Score += (int)(25 * _damage + 1));
    }

    public float Damage { get => _damage; set => _damage = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) != "Player")
            return;

        HealthBehaviour health = other.GetComponent<HealthBehaviour>();
        health.TakeDamage(Damage);
    }
}
