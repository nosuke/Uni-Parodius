using UnityEngine;
using System.Collections;

public class CreateurEffetsSpeciaux : MonoBehaviour {
	
	public static CreateurEffetsSpeciaux Instance;
	
	public ParticleSystem effetFraise;
	public ParticleSystem effetKiwi;
	public ParticleSystem effetPingouin;
	public ParticleSystem effetFeu;
	
	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}
		
		Instance = this;
	}

	public void Explosion(Vector3 position)
	{
		instantiate(effetFraise, position);
		instantiate(effetKiwi, position);
		instantiate(effetPingouin, position);
		instantiate(effetFeu, position);
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
			) as ParticleSystem;

		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
			);
		
		return newParticleSystem;
	}
}