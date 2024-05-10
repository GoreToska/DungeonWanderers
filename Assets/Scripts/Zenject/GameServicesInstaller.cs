using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameServicesInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<InputHandler>().FromNew().AsSingle().NonLazy();
	}
}
