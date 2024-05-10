using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
	private Animator _animator;
	private CharacterMovement _characterMovement;

	[SerializeField] private string _attackTriggerName = "Attack";
	[SerializeField] private string _attackCountName = "AttackCount";

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_characterMovement = GetComponent<CharacterMovement>();
	}

	private void Update()
	{
		_animator.SetFloat("Speed", _characterMovement.MovementSpeed);
	}

	public void PlayAttackAnimation(int attackCount)
	{
		_animator.SetInteger(_attackCountName, attackCount);
		_animator.SetTrigger(_attackTriggerName);
	}
}
