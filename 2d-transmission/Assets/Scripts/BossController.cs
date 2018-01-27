using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    int attack;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("MyEvent");
    }

    private IEnumerator MyEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f); // wait half a second
            attack = Random.Range(0, 2);
            //if (attack == 0) && ()
            {

            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
