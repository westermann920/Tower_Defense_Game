using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (var e in allEnemies)
        {
            EnemySpecs specs = e.GetComponent<EnemySpecs>();
        }
    }
}
