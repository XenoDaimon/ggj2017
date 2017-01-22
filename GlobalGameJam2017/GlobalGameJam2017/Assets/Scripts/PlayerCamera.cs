using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public GameObject player;
    private Vector3 position;

	// Use this for initialization
	void Start () {
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        position.z = -10;
        transform.position = position;
	}
	
	// Update is called once per frame
	void Update () {
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        transform.position = position;
    }
}
