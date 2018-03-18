using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardCanvas : MonoBehaviour {

    public GameObject ala_parent;
    Vector3 d_position, d_scale;
    Quaternion d_rotation;

    void Start()
    {
        d_rotation = Quaternion.FromToRotation(ala_parent.transform.up, transform.up);
        d_position = transform.position - ala_parent.transform.position;
        //d_scale = new Vector3(transform.localScale.x / ala_parent.transform.localScale.x, transform.localScale.y / ala_parent.transform.localScale.y, transform.localScale.z / ala_parent.transform.localScale.z);
    }

    void Update()
    {
        transform.position = ala_parent.transform.position + d_position;
        transform.rotation = d_rotation * ala_parent.transform.rotation;
        //transform.localScale = Vector3.Scale(ala_parent.transform.localScale, d_scale);
    }
}
