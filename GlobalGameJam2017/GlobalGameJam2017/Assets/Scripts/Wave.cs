using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    private Vector3 velocity;
    public int maxHit;
    private int nbHit = 0;
    private Color color;

    // Use this for initialization
    void Start () {
        color = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wave" || coll.gameObject.tag == "AbsorbWall" || coll.gameObject.tag == "Button" || coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Wall")
        {
            GameManager.gameManager.setNbBounce(GameManager.gameManager.getNbBounce() + 1);
            ++nbHit;
            color.a -= 1 / (float)maxHit;
            GetComponent<SpriteRenderer>().color = color;
        }
    }

    void Update () {
        transform.up = GetComponent<Rigidbody2D>().velocity;
        if (nbHit >= maxHit)
        {
            Destroy(gameObject);
        }
    }
}
