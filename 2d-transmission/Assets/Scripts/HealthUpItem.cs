using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpItem : MonoBehaviour {

	public static int destroySeconds = 2;
	public int recoverAmount = 20;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Kill time
	public static void startDying(GameObject o) {
		Destroy (o, destroySeconds);
	}

}
