using UnityEngine;
using System.Collections;

public class Sante : MonoBehaviour {

	public int hp = 1;
	public bool isEnemy = true;
	
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		if (hp <= 0)
		{
			CreateurEffetsSpeciaux.Instance.Explosion(transform.position);
			Destroy(gameObject);
			if (isEnemy)
			{
				CreateurEffetsSonores.Instance.MakeEnemyDeathSound();
			}
			else
			{
				CreateurEffetsSonores.Instance.MakePlayerDeathSound();
				TuerVicViper();
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Munition munition = otherCollider.gameObject.GetComponent<Munition>();
		if (munition != null)
		{
			if (munition.isEnemyShot != isEnemy)
			{
				Damage(munition.damage);
				Destroy(munition.gameObject);
			}
		}
	}

	void TuerVicViper ()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}