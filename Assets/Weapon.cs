using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem _weaponSwingTrail;

	private void Awake()
	{
		if(!_weaponSwingTrail)
			_weaponSwingTrail = GetComponentInChildren<ParticleSystem>();
	}

	public void ActivateTrail()
	{
		_weaponSwingTrail.Play();
	}

	public void DeactivateTrail()
	{
		_weaponSwingTrail.Stop();
	}
}
