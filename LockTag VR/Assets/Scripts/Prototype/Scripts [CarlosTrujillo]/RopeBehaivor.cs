using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehaivor : MonoBehaviour {



	private Rigidbody rb;

	// Use this for initialization
	void Awake () {



		rb = gameObject.GetComponent<Rigidbody> ();



		int childCount = transform.childCount;

		for (int i = 0; i < childCount; i++)
		{

			Transform t = transform.GetChild (i);

			ConfigurableJoint hinge = t.gameObject.GetComponent<ConfigurableJoint> ();

			hinge.connectedBody = 
				i == 0 ? rb : transform.GetChild (i - 1).GetComponent<Rigidbody> ();

			hinge.enableCollision = true;

		}
	}
}
