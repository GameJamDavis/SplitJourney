using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightCombatManager : MonoBehaviour
{
	public enum CombatAction { rock = 0, paper = 1, scissors = 2 }

	//public event Action<BattleResult> OnBattleComplete = delegate { };

	[SerializeField]
	private PlayerFighter playerFighterPrefab;
	[HideInInspector]
	public PlayerFighter playerFighter;

	[SerializeField]
	private EnemyFighter enemyFighterPrefab;
	[HideInInspector]
	public EnemyFighter enemyFighter;


	[SerializeField]
	private Button[] playerActionButtons;

	void Start()
	{
		StartCombat ();
	}

	public void StartCombat()
	{
		foreach (Button button in playerActionButtons)
		{
			button.interactable = false;
		}
		playerFighter = Instantiate(playerFighterPrefab);
		enemyFighter = Instantiate(enemyFighterPrefab);

		StartCoroutine(BattleFlow());
	}


	IEnumerator BattleFlow()
	{
		CombatAction enemyAction = (CombatAction)enemyFighter.PickNextAttack();

		CombatAction? playerAction = null;

		for(int i=0;i<playerActionButtons.Length;i++)
		{
			Button button = playerActionButtons[i];
			CombatAction action = (CombatAction)i;
			button.onClick.AddListener(() => { playerAction = action; });
			button.interactable = true;
		}

		while (!playerAction.HasValue)
		{
			yield return null;
		}

		for (int i = 0; i < playerActionButtons.Length; i++)
		{
			Button button = playerActionButtons[i];
			button.onClick.RemoveAllListeners();
			button.interactable = false;
		}

		yield return ResolveCombat(enemyAction, playerAction.Value);
	}

	IEnumerator ResolveCombat(CombatAction enemyAction, CombatAction playerAction)
	{
		int max = Enum.GetValues(typeof(CombatAction)).Length;

		if (((int)playerAction + 1) % max == (int)enemyAction)
		{
			//lose
			playerFighter.CurrentHealth-=2;
		}
		else if ((int)playerAction == ((int)enemyAction + 1) % max)
		{
			//win
			playerFighter.CurrentHealth++;
		}
		else
		{
			//tie
			playerFighter.CurrentHealth--;
		}

		yield return new WaitForSeconds(1);
	}
}
