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
        //Store reference to player contoller to modify current action map.
        _playerInput = GameManagerBehaviour.Instance.PlayerController;
    }

    /// <summary>
    /// Listens for an input and changes the binding at the current index to be the input pressed.
    /// </summary>
    /// <param name="index">The index of the binding in the action map to change.</param>
    public void Rebind(int index = 0)
    {
        //Store a reference to the index to use during clean up.
        _index = index;
        //Update button text to let the player know input is expected.
        _buttonTextBox.text = "Listening...";
        //Switch the current action map in order to start rebinding.
        //Rebinding for an action map cannot occur while that action map is being used.
        _playerInput.SwitchCurrentActionMap("Menu");

        //Start the interactive rebinding with the given index.
        _rebindAction.action.PerformInteractiveRebinding(_index)
            .OnComplete(OnRebindComplete)
            .Start();
    }

    public void OnRebindComplete(InputActionRebindingExtensions.RebindingOperation operation)
    {
        Debug.Log("Rebind completed");
        //Dispose of the rebinding operation to free up resources.
        operation.Dispose();
        //Update the button text to be the text of the new input.
        _buttonTextBox.text = _actionText + " - " + _rebindAction.action.bindings[_index].ToDisplayString();
        //Switch action map back to original action map.
        _playerInput.SwitchCurrentActionMap("Ship");
    }
}
