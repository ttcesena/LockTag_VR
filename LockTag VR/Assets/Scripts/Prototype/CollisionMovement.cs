using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMovement : MonoBehaviour {
    public GameObject target;
    public float force;
    private bool spinning;
    private Rigidbody ChairRigid;
    public Animator SpinningChair;

    // Use this for initialization
    void Start() {
        ChairRigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (spinning == true)
        {
            SpinningChair.SetBool("Spin", true);
            //ChairRigid.AddTorque(Vector3.up * force *Time.deltaTime);
        }
        if(spinning == false)
        {
            SpinningChair.SetBool("Spin", false);
        }
        //Debug.Log(spinning);

    }

   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            spinning = true;
            Debug.Log("collided");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == target)
        {
            spinning = true;
            Debug.Log("still colliding");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            spinning = false;
            Debug.Log("stopped colliding" + spinning);

        }
    }

}
