using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterMovementControl : MonoBehaviour {

	[Tooltip( "Plug in PlayArea , PlayArea contains DashTeleportScript" )]
	public VRTK.VRTK_DashTeleport refForVRTK_DashTeleport; //Play Area contains this script

	public Image dashIconLarge;
	public Image dashIconSmall;

	public Image TeleportIconLarge;
	public Image TeleportIconSmall;

	//Teleport Anywhere On/Off
	public GameObject turnOnTA;

	//Teleport To Waypoint On/Off
	public GameObject turnOnWT;


	public void Awake()
	{
		turnOnTA.SetActive (false);
		turnOnWT.SetActive (false);
	}

	// Update is called once per frame
	void Update () {


		//Teleport Anywhere On/Off
		if (Input.GetKey(KeyCode.Alpha1))
		{
			turnOnTA.SetActive(true);
			TeleportIconLarge.enabled = true;
			TeleportIconSmall.enabled = false;

			turnOnWT.SetActive(false);
			dashIconLarge.enabled = false;
			dashIconSmall.enabled = true;

		}

		//Teleport To Waypoint On/Off
		if (Input.GetKey(KeyCode.Alpha2))
		{
			turnOnWT.SetActive(true);
			dashIconLarge.enabled = true;
			dashIconSmall.enabled = false;

			turnOnTA.SetActive(false);
			TeleportIconLarge.enabled = false;
			TeleportIconSmall.enabled = true;
		}


		//Turn on Dash
		if (Input.GetKey (KeyCode.Alpha3)) 
		{
			refForVRTK_DashTeleport.blinkTransitionSpeed = 0f;
		}

		//Turn off Dash
		if (Input.GetKey (KeyCode.Alpha4)) 
		{
			refForVRTK_DashTeleport.blinkTransitionSpeed = 20f;
		}



	}
}
