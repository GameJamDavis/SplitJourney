using System;
using System.Collections;
using UnityEngine;

public class EnemyFighter : Fighter
{

	public override IEnumerator Turn(BattleManager battleManager)
	{
		yield break;
	}

	private int currentHealth;
	public override int CurrentHealth
	{
		get { return currentHealth; }
		set
		{
			currentHealth = Mathf.Clamp(value, 0, maxHeath);
		}
	}
	public int PickNextAttack()
	{
		return UnityEngine.Random.Range(0, 3);
	}
}
