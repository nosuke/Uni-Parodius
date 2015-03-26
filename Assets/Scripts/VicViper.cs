using UnityEngine;
using System.Collections;

public class VicViper : MonoBehaviour {

	public Vector2 speed = new Vector2(50, 50);
	private Vector2 movement;
	private Arme[] weapons;

	void Awake()
	{
		weapons = GetComponentsInChildren<Arme>();
	}

	void Update()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		movement = new Vector2(speed.x * inputX, speed.y * inputY);

		bool shoot1 = Input.GetButton("Fire1");
		bool shoot2 = Input.GetButton("Fire2");
		
		if (shoot1)
		{
			Arme weapon = weapons[0];
			if (weapon != null)
			{
				weapon.Attack(false);
				CreateurEffetsSonores.Instance.MakePlayerShot1Sound();
			}
		}
		else if (shoot2)
		{
			Arme weapon = weapons[1];
			if (weapon != null)
			{
				weapon.Attack(false);
				CreateurEffetsSonores.Instance.MakePlayerShot2Sound();
			}
		}

		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;

		Ennemi enemy = collision.gameObject.GetComponent<Ennemi>();
		if (enemy != null)
		{
			Sante enemyHealth = enemy.GetComponent<Sante>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
			
			damagePlayer = true;
		}

		if (damagePlayer)
		{
			Sante playerHealth = this.GetComponent<Sante>();
			if (playerHealth != null) playerHealth.Damage(1);
		}
	}
}