using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFacingCamera : MonoBehaviour {
	
	void Update ()
    {
        transform.LookAt(Camera.main.transform.GetChild(0).position);
    }
}

