using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour {
    Text txt;
	
	void Start () {
        txt = GetComponent<Text>();
        txt.text = "HighScore: " + PlayerPrefs.GetInt("Highscore");
    }

    private void OnEnable()
    {
        txt.text = "HighScore: " + PlayerPrefs.GetInt("Highscore");
    }
}
