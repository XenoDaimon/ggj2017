using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	private bool running = true;
	private Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	IEnumerator menuScene() {
		yield return new WaitForSeconds (3);
		GameManager.gameManager.LoadNextLevel (0);
	}

	void Update () {
		if (running) {
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("IdleThanks")) {
				StartCoroutine (menuScene());
				running = false;
			}
		}
	}
}
