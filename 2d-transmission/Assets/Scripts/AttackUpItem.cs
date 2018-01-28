using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUpItem : MonoBehaviour {
	public int baseDamage;
	public int attackIncreaseAmount;

	private static int damageBuff;
	private int damage;

	// Use this for initialization
	void Start () {
		damageBuff = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Always call on pickup so that the attackupitem damage can be modified
	void pickup() {
		damage = damage + baseDamage;
		damageBuff += attackIncreaseAmount;
		Destroy (this.gameObject);
	}

	// For the player to get the damage
	public int getDamage() {
		return damage;
	}
}
