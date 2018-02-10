using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsController : MonoBehaviour {

    public GameObject fireBall;
    public GameObject lightningStorm;
    public Transform spellSpawn;
    public float fireRate;
    public float nextFire;
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextFire)
        {
            nextFire = Time.time * fireRate;
            GameObject fireBallClone = Instantiate(fireBall, spellSpawn.position, spellSpawn.rotation) as GameObject;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject lightningStormClone = Instantiate(lightningStorm, spellSpawn.position, spellSpawn.rotation) as GameObject;
            Destroy(lightningStormClone, 1);
        }
    }
}
