using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpItem : MonoBehaviour {

	public int destroySeconds = 10;
	public int recoverAmount = 20;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, destroySeconds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

}
