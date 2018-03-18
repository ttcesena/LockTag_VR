using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBeingFlippedUpDown : MonoBehaviour {

	public VRTK.VRTK_SpringLever refVRTKSpring_Lever;

	public VRTK.VRTK_Control refVrtkControl;

	public float rotToGoDown;

	public float rotToGoUp;

	public bool startCheckSwitchUp;


	public bool switchBeginOff;

	
	// Update is called once per frame
	void Update () 
	{
		//Switch Starting Down
		if (refVrtkControl.value == refVRTKSpring_Lever.minAngle) 
		{
			startCheckSwitchUp = true;
			
		}
		if ( refVRTKSpring_Lever.value < rotToGoUp && startCheckSwitchUp) 
		{
			JointSpring leverSpring = refVRTKSpring_Lever.leverHingeJoint.spring;
			leverSpring.targetPosition = refVRTKSpring_Lever.GetSpringTarget (false);
			refVRTKSpring_Lever.leverHingeJoint.spring = leverSpring;

		}


		if (refVrtkControl.value == refVRTKSpring_Lever.maxAngle) 
		{
			startCheckSwitchUp = false;
		}
				
		if ( refVRTKSpring_Lever.value > rotToGoDown &&  !startCheckSwitchUp )
		{

			//Debug.Log ("going here");
			JointSpring leverSpring = refVRTKSpring_Lever.leverHingeJoint.spring;
			leverSpring.targetPosition = refVRTKSpring_Lever.GetSpringTarget (true);
			refVRTKSpring_Lever.leverHingeJoint.spring = leverSpring;
		}

			


		}
		

	
	}

		/*if (refVrtkControl.value == rotToGoUp && startCheckSwitchUp) 
			{
				if (refVrtkControl.value > rotToGoUp) 
				{
					//Debug.Log ("going here");
					JointSpring leverSpring = refVRTKSpring_Lever.leverHingeJoint.spring;
					leverSpring.targetPosition = refVRTKSpring_Lever.GetSpringTarget (false);
					refVRTKSpring_Lever.leverHingeJoint.spring = leverSpring;
					startCheckSwitchUp = false;
				}


			}*/
	

	



	



