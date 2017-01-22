using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Congrats : MonoBehaviour {
	void Start() {
		StartCoroutine (loadCredits ());
	}

	IEnumerator loadCredits() {
		yield return new WaitForSeconds (8);
		GameManager.gameManager.LoadNextLevel (SceneManager.GetSceneByName ("Credits").buildIndex);
	}
}
