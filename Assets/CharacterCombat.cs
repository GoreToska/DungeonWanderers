using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterAnimation))]
public class CharacterCombat : MonoBehaviour
{
	[SerializeField] private float _attackCooldown = 1f;
	[SerializeField] private Weapon _weapon;

	[Inject] private InputHandler _inputHandler;

	private CharacterAnimation _characterAnimation;
	private int _attackCount = 0;
	private float _attackTimer = 0;
	private bool _canAttack = true;

	private void Awake()
	{
		_characterAnimation = GetComponent<CharacterAnimation>();
		_weapon = GetComponentInChildren<Weapon>();
	}

	private void OnEnable()
	{
		_inputHandler.AttackAction += OnAttack;
	}

	private void OnDisable()
	{
		_inputHandler.AttackAction -= OnAttack;
	}

	private void Update()
	{
		if (_attackCount == 0 || _canAttack == false)
			return;

		_attackTimer += Time.deltaTime;

		if (_attackTimer > _attackCooldown)
		{
			_attackTimer = 0;
			_attackCount = 0;
		}
	}

	private void OnAttack()
	{
		if (!_canAttack)
			return;

        _canAttack = false;
		_characterAnimation.PlayAttackAnimation(_attackCount);
		_attackCount++;

		if (_attackCount == 3)
			_attackCount = 0;
	}

	public void IsAttacking()
	{
		_canAttack = false;
	}

	public void IsNotAttacking()
	{
		_canAttack = true;
		_attackTimer = 0;
	}

	public void ActivateTrail()
	{
		_weapon.ActivateTrail();
	}

	public void DeactivateTrail()
	{
		_weapon.DeactivateTrail();
	}
}
