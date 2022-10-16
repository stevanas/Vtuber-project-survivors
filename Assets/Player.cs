using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

	private void Awake()
	{ 
		healthBar.maxValue = maxHealth;
		healthBar.value = maxHealth;
	}

	public override void OnDamaged(int damageAmount)
	{
		base.OnDamaged(damageAmount);
		healthBar
			.DOValue(curHealth, 0.2f);
		Debug.Log(transform.name + " damaged!");

	}
	public override void Die()
	{
		base.Die();
		Debug.Log(transform.name + " died!");
		Destroy(this.gameObject);
	}
}
