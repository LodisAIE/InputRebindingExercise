using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    private SpaceshipMovementBehaviour _movementBehaviour;
    [SerializeField]
    private ProjectileSpawnerBehaviour _spawnerBehaviourLeft;
    [SerializeField]
    private ProjectileSpawnerBehaviour _spawnerBehaviourRight;

    private static GameObject _player;

    public static GameObject Player { get => _player; }

    // Start is called before the first frame update
    void Awake()
    {
        _movementBehaviour = GetComponent<SpaceshipMovementBehaviour>();
        _player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _movementBehaviour.MoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (Input.GetButtonDown("Fire1"))
        {
            _spawnerBehaviourLeft.FireProjectile();
            _spawnerBehaviourRight.FireProjectile();
        }
    }
}
