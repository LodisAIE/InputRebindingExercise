using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeBehaviour : MonoBehaviour
{
    public float TimeBetweenShakes;
    public float Strength;
    public float Duration;
    private float _shakeStartTime;
    private Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    public static void ShakeScreen()
    {
        Camera.main.GetComponent<ScreenShakeBehaviour>().Shake();
    }

    private IEnumerator StartShake()
    {
        while (Time.time - _shakeStartTime < Duration)
        {
            Vector3 position = new Vector3(Random.Range(0, Strength), Random.Range(0, Strength), 0);

            transform.position = _startPosition + position;

            yield return new WaitForSeconds(TimeBetweenShakes);
        }

        transform.position = _startPosition;

        yield return null;
    }

    public void Shake()
    {
        _shakeStartTime = Time.time;
        StartCoroutine(StartShake());
    }

}