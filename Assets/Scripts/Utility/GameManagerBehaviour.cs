using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    private int _score;
    private bool _paused;
    private static GameManagerBehaviour _instance;
    [SerializeField]
    private UnityEvent _onPause;
    [SerializeField]
    private UnityEvent _onUnpause;

    public int Score { get => _score; set => _score = value; }

    private void Awake()
    {
        _instance = this;
    }

    public static GameManagerBehaviour Instance
    {
        get
        {
            if (!_instance)
                _instance = new GameObject("GameManager").AddComponent<GameManagerBehaviour>();

            return _instance;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        if (_paused)
        {
            _onUnpause.Invoke();
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
            Time.timeScale = 1;
        }
    }

    public void Quit()
    {
        if (Application.isEditor)
            return;

        Application.Quit();
    }

    public void TogglePause()
    {
        _paused = !_paused;

        if (_paused)
        {
            _onPause.Invoke();
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
            Time.timeScale = 0;
        }
        else
        {
            _onUnpause.Invoke();
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
            Time.timeScale = 1;
        }
    }
}
