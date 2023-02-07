using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITextBehaviour : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private HealthBehaviour _playerHealth;
    [SerializeField]
    private TextMeshProUGUI _healthText;
    [SerializeField]
    private Gradient _healthGradient;

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score: " + GameManagerBehaviour.Instance.Score.ToString();
        _healthText.text = "Health: " + _playerHealth.Health.ToString();
        _healthText.color = _healthGradient.Evaluate(_playerHealth.Health / _playerHealth.MaxHealth);
    }
}
