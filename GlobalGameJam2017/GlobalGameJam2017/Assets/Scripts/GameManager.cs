using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;
	public float victoryScreenDuration = 1.0f;
	public RectTransform victoryPanel;

	private float time = 0;
    private int nbBounce = 0;
    private int nbShot = 0;
    private bool hasEnded = false;
	private bool loadingNextLevel = false;
	private string levelToLoad;

	// Use this for initialization
	void Awake () {
        gameManager = this;
	}
	
    public int getNbBounce()
    {
        return nbBounce;
    }
    
    public void setNbBounce(int bounce)
    {
        nbBounce = bounce;
    }

    public int getNbShot()
    {
        return nbShot;
    }

    public void setNbShot(int shot)
    {
        nbShot = shot;
    }

    public bool getHasEnded()
    {
        return hasEnded;
    }

    public void setHasEnded(bool end)
    {
        hasEnded = end;
    }

	public float getTime() {
		return time;
	}

	public void resetTime() {
		time = 0;
	}

    // Update is called once per frame
    void Update () {
		if (Input.GetButton ("Cancel") && SceneManager.GetActiveScene ().buildIndex != 0) {
			LoadNextLevel(0, false);
		}
		if (hasEnded && !loadingNextLevel)
			LoadNextLevel ();
		else
	        time += Time.deltaTime;
	}

	public void LoadNextLevel(string levelName) {
		levelToLoad = levelName;
		LoadNextLevel (-2);
	}

	public void LoadNextLevel(int index = -1, bool victoryScreen = true) {
		loadingNextLevel = true;
		StartCoroutine (ChangeLevel(index, true, victoryScreen));
	}

	public void LoadLevelNoVictoryScreen(int index = -1) {
		LoadNextLevel (index, false);
	}

	IEnumerator ChangeLevel(int index = -1, bool fade = true, bool victoryScreen = true) {
		if (victoryScreen && SceneManager.GetActiveScene ().buildIndex != 0 && victoryPanel) {
			// Save player score

			// Update and show Victory screen
			victoryPanel.FindChild ("TimeText").GetComponent<Text> ().text = time.ToString ("0.00") + "s";
			victoryPanel.FindChild ("BouncesText").GetComponent<Text> ().text = nbBounce + " bounces";
			victoryPanel.FindChild ("ShotsText").GetComponent<Text> ().text = nbShot + " soundwaves";
			victoryPanel.gameObject.SetActive (true);
			Image img = victoryPanel.GetComponent<Image> ();
			for (; img.color.a < 1.0f; img.color = new Color (img.color.r, img.color.g, img.color.b, img.color.a + 0.1f))
				yield return new WaitForSeconds (0.1f);
			yield return new WaitForSeconds (victoryScreenDuration);
		}

		if (fade) {
			float fadeTime = gameManager.GetComponent<Fading> ().BeginFade (1);
			yield return new WaitForSeconds (fadeTime);
		}
		if (index == -1)
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		else if (index == -2)
			SceneManager.LoadScene (levelToLoad);
		else
			SceneManager.LoadScene (index);
		loadingNextLevel = false;
	}

	public void ExitGame() {
		Application.Quit();
	}
}
