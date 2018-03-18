using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {


	public GameObject socketColor;

	public void SocketColorChange()
	{
		socketColor.GetComponent<Renderer> ().material.color = Color.blue;
	}

	public void SocketColorRevert()
	{
		socketColor.GetComponent<Renderer> ().material.color = Color.green;
	}
}
