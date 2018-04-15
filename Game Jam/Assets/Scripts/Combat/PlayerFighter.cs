using System;
using System.Collections;
using UnityEngine;

public class PlayerFighter : Fighter
{
	public override IEnumerator Turn(BattleManager battleManager)
	{
		throw new NotImplementedException();
	}
	public override void Start()
	{
		base.Start();
	}
	public override int CurrentHealth
	{
		get
		{
			return Player.Instance.health;
		}

		set
		{
			Player.Instance.health = Mathf.Clamp(value, 0, maxHeath);
		}
	}
}
