using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour 
{
	public float speed = 18; // Traverse Speed Heli.
    //public Transform tracker;
	private Rigidbody rig; // Body of the Helicopter.
	public Camera cam; // Camera that looks at the Heli.

	void Start () 
	{
		rig = GetComponent<Rigidbody>(); // Rigidbody of the 

	}

	void Update()
	{
		float hAxis = Input.GetAxis("Horizontal"); // Horizontal Movement by pressing left and right.
		float vAxis = Input.GetAxis("Vertical"); // Vertical Movement by pressing up and down.

		Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime; // Move in the space above the playground.

		rig.MovePosition(transform.position + movement); // Move Rigidbody position

		if(Input.GetKeyUp(KeyCode.Space)) // If pressed Space
		{
			cam.enabled = !cam.enabled; // Change Camera.
		}

        //transform.rotation = tracker.transform.rotation;
	}
}
