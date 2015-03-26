using UnityEngine;
using System.Collections;

public class CreateurEffetsSonores : MonoBehaviour {

	public static CreateurEffetsSonores Instance;
	
	public AudioClip playerShot1Sound;
	public AudioClip playerShot2Sound;
	public AudioClip enemyShotSound;
	public AudioClip playerDeathSound;
	public AudioClip enemyDeathSound;
	
	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}

	public void MakePlayerShot1Sound()
	{
		MakeSound(playerShot1Sound);
	}

	public void MakePlayerShot2Sound()
	{
		MakeSound(playerShot2Sound);
	}

	public void MakeEnemyShotSound()
	{
		MakeSound(enemyShotSound);
	}

	public void MakePlayerDeathSound()
	{
		MakeSound(playerDeathSound);
	}

	public void MakeEnemyDeathSound()
	{
		MakeSound(enemyDeathSound);
	}
	
	private void MakeSound(AudioClip originalClip)
	{
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}