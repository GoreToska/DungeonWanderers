using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class CharacterMovement : MonoBehaviour
{
	[Header("Movement Configuration")]
	[SerializeField] private MovementConfiguration _movementConfiguration;

	[Inject] private InputHandler _inputHandler;

	private bool _canMove = true;
	private CharacterController _characterController;
	private Vector2 _lerpedInput;
	private Vector3 _movementVector;
	private Vector2 _movementInput;
	private Camera _camera;

	private void Awake()
	{
		_camera = Camera.main;
		_characterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		if(!_canMove)
		{
			_lerpedInput = Vector2.zero;
			_movementVector = Vector3.zero;

			return;
		}

		_lerpedInput = Vector2.Lerp(_lerpedInput, GetRelativeInput(_movementInput), _movementConfiguration.MovementLerp * Time.deltaTime);
		_movementVector = new Vector3(_lerpedInput.x, 0, _lerpedInput.y);

		HandleRotation();
		HandleMovement();
	}

	private void OnEnable()
	{
		_inputHandler.MovementAction += OnMove;
	}

	private void OnDisable()
	{
		_inputHandler.MovementAction -= OnMove;
	}

	private void HandleMovement()
	{
		_movementVector = AddGravity(_movementVector);
		_characterController.Move(_movementVector * _movementConfiguration.MovementSpeed * Time.deltaTime);
	}

	private void HandleRotation()
	{
		if (_movementVector != Vector3.zero)
		{
			Quaternion movementRotation = Quaternion.LookRotation(_movementVector, Vector3.up);

			transform.rotation = Quaternion.RotateTowards(transform.rotation, movementRotation, _movementConfiguration.RotationSpeed * Time.deltaTime);
		}
	}

	private Vector3 AddGravity(Vector3 baseVector)
	{
		return new Vector3(baseVector.x, baseVector.y - 5, baseVector.z);
	}

	private void OnMove(Vector2 movementVector)
	{
		_movementInput = movementVector;
	}

	private Vector2 GetRelativeInput(Vector2 input)
	{
		var moveDirection =
		   new Vector3(_camera.transform.forward.x, 0, _camera.transform.forward.z) * input.y;
		moveDirection = moveDirection +
			new Vector3(_camera.transform.right.x, 0, _camera.transform.right.z) * input.x;

		return new Vector2(moveDirection.normalized.x, moveDirection.normalized.z);
	}

	public void StopMovement()
	{
		_canMove = false;
	}

	public void StartMovement()
	{
		_canMove = true;
	}

	public float MovementSpeed
	{
		get { return new Vector3(_movementVector.x, 0, _movementVector.z).magnitude; }
	}
}
