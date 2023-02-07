using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovementBehaviour : MonoBehaviour
{
    private Vector2 _moveDirection;
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _xMin;
    [SerializeField]
    private float _xMax;
    [SerializeField]
    private float _yMin;
    [SerializeField]
    private float _yMax;

    private Vector2 _velocity;

    public Vector2 MoveDirection { get => _moveDirection; set => _moveDirection = value; }
    public Vector2 Velocity { get => _velocity; private set => _velocity = value; }
    public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }

    // Update is called once per frame
    void FixedUpdate()
    {
        Velocity = _moveDirection * MovementSpeed * Time.deltaTime;
        transform.position += new Vector3(Velocity.x, Velocity.y, 0);

        float xPos = Mathf.Clamp(transform.position.x, _xMin, _xMax);
        float yPos = Mathf.Clamp(transform.position.y, _yMin, _yMax);
        transform.position = new Vector3(xPos, yPos, 0);    
    }
}
