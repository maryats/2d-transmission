using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackUpItem : MonoBehaviour {

	public Text damageText; // UI displays how much damage each player deals

	// amount by which future attack item increases
	public int attackIncreaseAmount; 

	// total buff - to be applied to future attack items
	public static int damageBuff = 0; 

	//	public int baseDamage; TODO delete?

	// how much damage this item deals
	private int damage;

//	public enum ItemLevel {
//		LOW, // 0-50
//		MID, // 51-100
//		HIGH // 101+
//	}

	// Use this for initialization
	void Start () {
		damage = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Always call on pickup so that the attackupitem damage can be modified
	void pickup() {
		damage = damage + damageBuff;
		damageBuff += attackIncreaseAmount;

		// hide object from screen and make it not pick-up-able
		this.gameObject.SetActive (false); // TODO does this work?
	}

	// For the player to get the damage
	public int getDamage() {
		return damage;
	}

//	public ItemLevel getItemLevel() {
//		if (damage <= 50) {
//			return ItemLevel.LOW;
//		} else if (damage <= 100) {
//			return ItemLevel.MID;
//		} else {
//			return ItemLevel.HIGH;
//		}
//	}

	void setDamageText() {
		damageText.text = "DMG: " + damage.ToString ();
	}
}
