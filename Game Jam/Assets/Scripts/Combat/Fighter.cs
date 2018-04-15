using System;
using System.Collections;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
	public event Action OnDeath = delegate { };

	public int maxHeath;
	public int attack;
	
	public abstract int CurrentHealth
	{
		get;
		set;
	}

	public virtual void Start()
	{
	}

	public abstract IEnumerator Turn(BattleManager battleManager);

	public bool IsAlive()
	{
		return CurrentHealth > 0;
	}
}
