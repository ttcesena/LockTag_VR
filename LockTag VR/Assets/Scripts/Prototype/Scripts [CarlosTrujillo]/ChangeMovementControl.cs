using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeMovementControl : MonoBehaviour {

	public VRTK.VRTK_SDKManager refForVRTK_SDKManager;
	public VRTK.VRTK_DashTeleport refForVRTK_DashTeleport;

	public GameObject leftTeleportControl;
	public GameObject rightTeleportControl;
	public GameObject leftLocomotionControl;
	public GameObject rightLocomotionControl;

	public Image teleportIcon;
	public Image teleportIconSmall;
	public Image dashIcon;
	public Image dashIconSmall;
	public Image OculusControllerIcon;
	public Image OculusControllerIconSmall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		// Press 1 on the keyboard to change to teleport mode
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{

			//Assigns proper controllers to SDKManager
			refForVRTK_SDKManager.scriptAliasLeftController = leftTeleportControl ;
			refForVRTK_SDKManager.scriptAliasRightController = rightTeleportControl;
			refForVRTK_DashTeleport.blinkTransitionSpeed = .6f;

			//Turns Icons on and off
			teleportIconSmall.enabled = false;
			dashIconSmall.enabled = true;
			OculusControllerIconSmall.enabled = true;

			teleportIcon.enabled = true;
			dashIcon.enabled = false;
			OculusControllerIcon.enabled = false;

		}

		// Press 2 on the keyboard to change to dash mode
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			//Turns off blink that happens when teleporting which turns it into a dash effect
			refForVRTK_DashTeleport.blinkTransitionSpeed = 0f;

			//Turns Icons on and off
			teleportIconSmall.enabled = true;
			dashIconSmall.enabled = false;
			OculusControllerIconSmall.enabled = true;

			teleportIcon.enabled = false;
			dashIcon.enabled = true;
			OculusControllerIcon.enabled = false;

		}

		// Press 3 on the keyboard to change to locomotion mode (yuck!)
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			//Assigns proper controllers to SDKManager
			refForVRTK_SDKManager.scriptAliasLeftController = leftLocomotionControl ;
			refForVRTK_SDKManager.scriptAliasRightController = rightLocomotionControl;

			//Turns Icons on and off
			teleportIconSmall.enabled = true;
			dashIconSmall.enabled = true;
			OculusControllerIconSmall.enabled = false;

			teleportIcon.enabled = false;
			dashIcon.enabled = false;
			OculusControllerIcon.enabled = true;

		}

        // Restart current scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

	}
}
