using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekEnemyBehaviour : EnemyBehaviour
{
    private SpaceshipMovementBehaviour _movementBehaviour;
    private Transform _target;

    // Start is called before the first frame update
    void Awake()
    {
        _movementBehaviour = GetComponent<SpaceshipMovementBehaviour>();
    }

    private void Start()
    {
        if (!InputBehaviour.Player)
            return;

        _target = InputBehaviour.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_target)
            return;

        _movementBehaviour.MoveDirection = (_target.position - transform.position).normalized;

        if (_movementBehaviour.MoveDirection.magnitude > 0)
            transform.up = new Vector2(_movementBehaviour.MoveDirection.x, _movementBehaviour.MoveDirection.y);
    }
}
