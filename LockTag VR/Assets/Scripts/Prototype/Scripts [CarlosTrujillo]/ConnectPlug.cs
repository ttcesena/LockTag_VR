using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectPlug : MonoBehaviour {

	public GameObject connector;


	public Rigidbody rbConnector;

	public VRTK.VRTK_InteractGrab isLeftHandGrabbing;

	public VRTK.VRTK_InteractGrab isRightHandGrabbing;

	public ChangeColor runFunction;

	public bool isConnected;

	public bool plugWithinRange;

	public Vector3 rot;


	void OnTriggerStay (Collider other)
	{





		if (other.transform.tag == "Connector") 
		{

			runFunction.SocketColorChange ();

			plugWithinRange = true;

			if (isLeftHandGrabbing.grabPressed || isRightHandGrabbing.grabPressed) 
			{
				rbConnector.isKinematic = false;

			



			}

			if (!isLeftHandGrabbing.grabPressed && !isRightHandGrabbing.grabPressed) 
			{
				connector.transform.position = this.transform.position;

				rbConnector.isKinematic = true;

				isConnected = true;
			
				connector.transform.LookAt(rot) ;


			}
		}

	}

	void OnTriggerExit (Collider other)
	{

		runFunction.SocketColorRevert ();

		plugWithinRange = false;

		rbConnector.isKinematic = false;

		isConnected = false;

	}
}



	