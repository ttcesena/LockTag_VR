using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTeleportPoints : MonoBehaviour {

	public VRTK.VRTK_Pointer vrtk_pointerRefRightController;

	public VRTK.VRTK_Pointer vrtk_pointerRefLeftController;

	public GameObject[] teleportPoints;

	public bool  checkedAlready;

	// Use this for initialization
	void Awake () 
	{
		teleportPoints = GameObject.FindGameObjectsWithTag ("DestinationPoint");
		
	}
	
	// Update is called once per frame
	void Update () {

		if (vrtk_pointerRefRightController.IsPointerActive () || vrtk_pointerRefLeftController.IsPointerActive() ) {

			if (checkedAlready) 
			{
				foreach (GameObject go in teleportPoints) 
				{
					go.GetComponent<VRTK.VRTK_DestinationPoint> ().enableTeleport = true;
					//Debug.Log ("teleport on");
					checkedAlready = false;
				}
			}

		} 
		else if (!vrtk_pointerRefRightController.IsPointerActive () && !vrtk_pointerRefLeftController.IsPointerActive() && !checkedAlready) 
		{
			foreach (GameObject go in teleportPoints) 
			{
				go.GetComponent<VRTK.VRTK_DestinationPoint> ().enableTeleport = false;
				//Debug.Log ("teleport off");
				checkedAlready = true;
			}

		}





	}
}
