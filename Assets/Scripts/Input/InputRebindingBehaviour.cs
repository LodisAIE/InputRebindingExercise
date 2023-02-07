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
    private PlayerInput _playerInput;

    private string _previousButtonText;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GameManagerBehaviour.Instance.PlayerController;
    }

    public void Rebind()
    {
        _previousButtonText = _buttonTextBox.text;
        _buttonTextBox.text = "Listening...";
        _playerInput.SwitchCurrentActionMap("Menu");

        _rebindAction.action.PerformInteractiveRebinding(0)
            .OnComplete(OnRebindComplete)
            .Start();
    }

    public void RebindComposite(int index)
    {
        _previousButtonText = _buttonTextBox.text;
        _buttonTextBox.text = "Listening...";
        _playerInput.SwitchCurrentActionMap("Menu");

        _rebindAction.action.PerformInteractiveRebinding(0).WithTargetBinding(index)
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(OnRebindComplete)
            .Start();
    }

    public void OnRebindComplete(InputActionRebindingExtensions.RebindingOperation operation)
    {
        Debug.Log("Rebind completed");
        operation.Dispose();
        _buttonTextBox.text = _previousButtonText + _rebindAction.action.GetBindingDisplayString();
        _playerInput.SwitchCurrentActionMap("Ship");
    }
}
