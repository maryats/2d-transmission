using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpItem : MonoBehaviour {

	public int destroySeconds;
	public int recoverAmount;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, destroySeconds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onPickup() {
		Destroy (this.gameObject);
	}
}
