using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class InputRebindingBehaviour : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _buttonTextBox;
    [SerializeField]
    private InputActionReference _rebindAction;
    [SerializeField]
    private string _actionText;
    private PlayerInput _playerInput;
    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GameManagerBehaviour.Instance.PlayerController;
    }

    public void Rebind(int index = 0)
    {
        _index = index;
        _buttonTextBox.text = "Listening...";
        _playerInput.SwitchCurrentActionMap("Menu");

        _rebindAction.action.PerformInteractiveRebinding(_index)
            .OnComplete(OnRebindComplete)
            .Start();
    }

    public void OnRebindComplete(InputActionRebindingExtensions.RebindingOperation operation)
    {
        Debug.Log("Rebind completed");
        operation.Dispose();
        _buttonTextBox.text = _actionText + " - " + _rebindAction.action.bindings[_index].ToDisplayString();
        _playerInput.SwitchCurrentActionMap("Ship");
    }
}
