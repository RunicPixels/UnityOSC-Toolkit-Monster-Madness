using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCSendExample : MonoBehaviour {

	public string targetIP = "10.200.200.30";
	public int targetPort = 1234;
	public string messageAddress = "/Audio1";
    public string buildingTag = "default";

	UnityOSC.OSCClient client;

	void Start() {
		client = new UnityOSC.OSCClient (System.Net.IPAddress.Parse (targetIP), targetPort);
	}

	// Update is called once per frame
	//void OnTriggerEnter ( Collider other ) {
	//	if(other.tag == "Fist")SendMessage ();
	//}

    void OnCollisionEnter ( Collision other)
    {
        Debug.Log("Test1");
        if (other.collider.tag == buildingTag) SendMessage();
    }

	void SendMessage() {
		UnityOSC.OSCMessage msg = new UnityOSC.OSCMessage (messageAddress);
		msg.Append (Time.time);

		client.Send (msg);
		client.Flush ();
		Debug.Log ("sent");
	}

	void OnDestroy() {
		client.Close ();
	}
}