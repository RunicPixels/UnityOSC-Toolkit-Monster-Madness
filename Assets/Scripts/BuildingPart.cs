using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Asset
public class BuildingPart : MonoBehaviour
{
	public BuildingPart connecting; // Building part this building is part of. (below this building)
	public float snapThreshold = 0.01f; // Snapping the buildings together.
	private float distanceToBottom = 0; // Distance between the building
	public bool isFoundation = false, broken = false; // Defining if the building is a foundation, and wether it's broken.
	public GameObject smokeParticles; // Particles used when building has been destroyed.
    public Material devastated; // Broken Building Textures.
    public Renderer rend; // Mesh Renderer used for the building.

    public void Start ()
	{
        if(connecting != null)distanceToBottom = Vector3.Distance (transform.position, connecting.transform.position); // Alligning Buildings.
	}

	public void Update ()
	{
		if (!broken) //not broken
		{
			if (!isFoundation) // not a foundation
			{
                //snapping
				float distance = Vector3.Distance (transform.position, connecting.transform.position) - distanceToBottom;
				Debug.Log (distance);
				if (distance > snapThreshold)
					Break (); // Break the building.
            }
			else
			{
                // if a gameobject to connect to exists.
                if (connecting != null)
                {
                    if (connecting.broken)
                        Break(); // Break the building.
                }
			}
		}
	}

	public void Break () // Casts when the object has been broken.
	{
		broken = true; // Defines the building as broken.
		smokeParticles.SetActive (true); // Enables Smoke Particles.
        rend.sharedMaterial = devastated; // Changes building texture to the broken one.
    }
}