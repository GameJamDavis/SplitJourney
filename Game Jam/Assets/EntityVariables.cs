using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityScript))]
public class EntityVariables : MonoBehaviour {

	public int speed;
	public int attack;
	public int maxHealth;
	public int currentHealth;



	public int getSpeed()
	{
		speed = Random.Range (0, 9);
		return speed;
	}

	public int getAttack()
	{
		return attack;
	}

	public int takeDamage(int d) //d will be attack of enemy or player
	{
		currentHealth = currentHealth - d;
		Mathf.Clamp (currentHealth, 0, maxHealth);
		//Mathf.Clamp(currentHealth,min,max);
		return currentHealth;

	}

}
