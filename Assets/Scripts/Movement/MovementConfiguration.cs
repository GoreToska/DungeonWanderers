using UnityEngine;

[CreateAssetMenu(fileName = "New Movement Configuration", menuName = "Configurations/Movement")]
public class MovementConfiguration : ScriptableObject
{
	[field: SerializeField] public float MovementSpeed { get; private set; }
	[field: SerializeField] public float SprintSpeedMultiplier { get; private set; }
	[field: SerializeField] public float MovementLerp { get; private set; }
	[field: SerializeField] public float Gravity { get; private set; }
	[field: SerializeField] public float RotationSpeed { get; private set; }

	private void OnValidate()
	{
		if (MovementSpeed < 0)
			MovementSpeed = -MovementSpeed;
		if (SprintSpeedMultiplier < 0)
			SprintSpeedMultiplier = -SprintSpeedMultiplier;
		if (MovementLerp < 0)
			MovementLerp = -MovementLerp;
		if (Gravity < 0)
			Gravity = -Gravity;
		if(RotationSpeed < 0)
			RotationSpeed = -RotationSpeed;
	}
}
