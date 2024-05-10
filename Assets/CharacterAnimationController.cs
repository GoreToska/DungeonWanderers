using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
	private Animator _animator;
	private CharacterMovement _characterMovement;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_characterMovement = GetComponent<CharacterMovement>();
	}

	private void Update()
	{
		_animator.SetFloat("Speed", _characterMovement.MovementSpeed);
	}
}
