using UnityEngine.Events;
using UnityEngine;

public class InputHandler
{
	private StandardControls _inputActions;

	public UnityAction<Vector2> MovementAction;
	public UnityAction AttackAction;

	public InputHandler()
	{
		_inputActions = new StandardControls();

		_inputActions.Game.Attack.performed += i => AttackAction?.Invoke();
		_inputActions.Game.Movement.performed += i => MovementAction?.Invoke(i.ReadValue<Vector2>());

		_inputActions.Enable();
	}

	public void EnableInput()
	{
		_inputActions.Enable();
	}

	public void DisableInput()
	{
		_inputActions.Disable();
	}
}
