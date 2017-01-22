using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wave")
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                GetComponent<Animator>().SetTrigger("isActive");
                transform.GetChild(i).GetComponent<Door>().switchState();
                GetComponent<AudioSource>().Play();
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
