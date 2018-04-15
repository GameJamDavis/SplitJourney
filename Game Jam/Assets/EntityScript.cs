using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityVariables))]
public class EntityScript : MonoBehaviour {

	public EntityVariables entityVariables;

	void Start()
	{
		entityVariables = GetComponent<EntityVariables>();
	}

	public virtual IEnumerator Turn()
	{
		yield break;

	}
}
