using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineMechanics : MonoBehaviour {
	

	public Timer refTimerScript;

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "PlayerBodyMass") 
		{ 
			
			Debug.Log ( "You took " + refTimerScript.min +  ":" + refTimerScript.sec + " to get to objective");

			//Stop the timer and reset to 0
			refTimerScript.startTimer = false;
			refTimerScript.t = 0f;

		}
	}
}
