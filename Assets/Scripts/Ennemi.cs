using UnityEngine;
using System.Collections;

public class Ennemi : MonoBehaviour {
	
	private bool hasSpawn;
	private Mouvement moveScript;
	private Arme[] weapons;
	
	void Awake()
	{
		weapons = GetComponentsInChildren<Arme>();
		moveScript = GetComponent<Mouvement>();
	}
	
	void Start()
	{
		hasSpawn = false;
		collider2D.enabled = false;
		moveScript.enabled = false;
		
		foreach (Arme weapon in weapons)
		{
			weapon.enabled = false;
		}
	}
	
	void Update()
	{
		if (hasSpawn == false)
		{
			if (renderer.IsVisibleFrom(Camera.main))
			{
				Spawn();
			}
		}
		else
		{
			foreach (Arme weapon in weapons)
			{
				if (weapon != null && weapon.enabled && weapon.CanAttack)
				{
					weapon.Attack(true);
					CreateurEffetsSonores.Instance.MakeEnemyShotSound();
				}
			}
			
			if (renderer.IsVisibleFrom(Camera.main) == false)
			{
				Destroy(gameObject);
			}
		}
	}
	
	private void Spawn()
	{
		hasSpawn = true;
		collider2D.enabled = true;
		moveScript.enabled = true;
		
		foreach (Arme weapon in weapons)
		{
			weapon.enabled = true;
		}
	}
}