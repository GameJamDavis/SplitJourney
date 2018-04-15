using System;
using System.Collections;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
	public event Action OnDeath = delegate { };

	public int maxHeath;

	private int currentHealth;
	public int CurrentHealth
	{
		get { return currentHealth; }
		set
		{
			if (value == 0 && currentHealth > 0)
			{
				currentHealth = Mathf.Clamp(value, 0, maxHeath);
			}
		}
	}

	public abstract IEnumerator Turn();

	public bool IsAlive()
	{
		return currentHealth > 0;
	}
}
