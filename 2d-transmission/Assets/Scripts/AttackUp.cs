using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : MonoBehaviour {

	public int destroySeconds = 10;
	public int attackIncreaseAmount = 5;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, destroySeconds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
