using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {

    public float LifeTime;
    private Color color;

    // Use this for initialization
    void Start () {
        color = GetComponent<SpriteRenderer>().color;
        Debug.Log(color);
    }

	// Update is called once per frame
	void Update () {
        float a = color.a;
        Debug.Log("a : " + a);
        Debug.Log("LifeTime :" + LifeTime);
        Debug.Log("Delta : " + Time.deltaTime);
        color.a = a - Time.deltaTime / LifeTime;
        GetComponent<SpriteRenderer>().color = color;
        if (color.a <= 0f)
            Destroy(gameObject);
    }
}
