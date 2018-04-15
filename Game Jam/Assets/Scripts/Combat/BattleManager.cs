using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
	public enum BattleResult { Undecided, PlayerWin, PlayerLost }

	public event Action<BattleResult> OnBattleComplete = delegate { };

	[SerializeField]
	private PlayerFighter playerFighterPrefab;
	public PlayerFighter playerFighter;

	[SerializeField]
	private EnemyFighter enemyFighterPrefab;
	public EnemyFighter enemyFighter;

	public int direction;

	private List<Fighter> fighters;

	void Start()
	{
		StartCombat ();
	}

	public void StartCombat()
	{
		playerFighter = Instantiate(playerFighterPrefab);
		enemyFighter = Instantiate(enemyFighterPrefab);
		fighters = new List<Fighter>() { playerFighter, enemyFighter };

		StartCoroutine(BattleFlow());
	}


	IEnumerator BattleFlow()
	{
		while (true)
		{
			foreach (Fighter fighter in fighters)
			{
				if (fighter.IsAlive()) // just in case
				{
					yield return fighter.Turn();
				}

				BattleResult result = IsBattleOver();
				if (result != BattleResult.Undecided)
				{
					OnBattleComplete(result);
					yield break;
				}
			}
		}
	}

	BattleResult IsBattleOver()
	{
		if (!playerFighter.IsAlive())
		{
			return BattleResult.PlayerLost;
		}
		else if(!enemyFighter.IsAlive())
		{
			return BattleResult.PlayerWin;
		}
		else
		{
			return BattleResult.Undecided;
		}
	}
}
