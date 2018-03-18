using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeStateDoorCheck : MonoBehaviour {

    public GameObject door;
    [Range(0f, -180f)]
    public float doorAngleForCheck = -20f;

    public bool fridgeDoorCheck = false;

    private void FixedUpdate()
    {
        if (!fridgeDoorCheck && 360 + doorAngleForCheck > door.transform.rotation.eulerAngles.y)
            fridgeDoorCheck = true;
    }
}
