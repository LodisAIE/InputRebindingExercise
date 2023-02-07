using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3 _offset;
    [SerializeField]
    private float _speed;
    private float _time;
    private Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.LerpUnclamped(_startPosition, _startPosition + _offset, Mathf.Cos(_time += Time.deltaTime * _speed));
    }
}
