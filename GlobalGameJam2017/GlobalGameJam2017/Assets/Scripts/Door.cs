using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool isOpen;

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().SetBool("isOpen", isOpen);
	}
	
    public void switchState()
    {
        isOpen = !isOpen;
        GetComponent<Animator>().SetBool("isOpen", isOpen);
        GetComponent<BoxCollider2D>().enabled = !isOpen;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
