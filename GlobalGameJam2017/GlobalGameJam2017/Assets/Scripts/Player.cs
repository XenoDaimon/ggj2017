using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject wave;
    public GameObject canon;
    public float speed;
    public float rotate;
    public float speedWave;
    private AudioSource src;

    // Use this for initialization
    void Start () {
        src = transform.GetChild(0).GetComponent<AudioSource>();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            GameManager.gameManager.setHasEnded(true);
        }
    }

    // Update is called once per frame
    void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        if (Input.GetButton("Vertical"))
        {
            transform.position = Vector2.MoveTowards(transform.position, canon.transform.position, speed * Time.deltaTime * Input.GetAxisRaw("Vertical"));
        }
        if (Input.GetButton("Horizontal"))
        {
            transform.Rotate(0, 0, speed * Time.deltaTime * Input.GetAxisRaw("Horizontal") * -rotate, Space.Self);
        }
        if (Input.GetButtonDown("Jump"))
        {
            GameObject obj = (GameObject)Instantiate(wave, canon.transform.position, this.transform.rotation);
            obj.GetComponent<Rigidbody2D>().velocity = -(transform.position - canon.transform.position) * speedWave;
            GameManager.gameManager.setNbShot(GameManager.gameManager.getNbShot() + 1);
            src.Play();
        }
    }
}
