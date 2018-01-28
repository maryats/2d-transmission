using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

    //bool beenTouched;
    GameObject gatherer;
	// Use this for initialization
	void Start () {
        //bool beenTouched = false;
        gatherer = GameObject.Find("Gatherer");
    }
	
	// Update is called once per frame
	void Update () {
      
	}

    void OnCollisionEnter2D(Collision2D gathererCollide)
    {
        GameObject colliding = gathererCollide.gameObject;
        if (colliding.tag == "Gatherer")
        {
            //beenTouched = true;
            Debug.Log("Gathered");
            Destroy(gameObject);
            
        }
    }
}
