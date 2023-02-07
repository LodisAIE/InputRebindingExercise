using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnObject;
    [SerializeField]
    private float _spawnDelay;
    private float _timeSinceLastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        _timeSinceLastSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _timeSinceLastSpawn >= _spawnDelay)
        {
            Instantiate(_spawnObject, transform.position, _spawnObject.transform.rotation);
            _timeSinceLastSpawn = Time.time;
        }
    }
}
