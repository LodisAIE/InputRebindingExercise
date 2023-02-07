using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

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

    public void Move(CallbackContext context)
    {
        _movementBehaviour.MoveDirection = context.ReadValue<Vector2>();
    }

    public void Fire(CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;

        _spawnerBehaviourLeft.FireProjectile();
        _spawnerBehaviourRight.FireProjectile();
    }

    public void Pause(CallbackContext context)
    {
        GameManagerBehaviour.Instance.TogglePause();
    }
}
