using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    private float lifeTime = 1.0f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, lifeTime);
	}
}
