using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreScript : MonoBehaviour {

    Text txtScore;
    public Text txtHighScore;
    
    void Start () {

	}

    private void OnEnable()
    {
        txtScore = GetComponent<Text>();
        CarregarHighScore();
    }

    public void CarregarHighScore()
    {
        if (PlayerPrefs.GetInt("Highscore") >= Contador.points)
        {
            txtHighScore.color = new Color(19 / 255f, 0, 1f, 1f);
            txtHighScore.text = "HighScore: " + PlayerPrefs.GetInt("Highscore");
            txtScore.text = "Points: " + Contador.points;
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", Contador.points);
            txtHighScore.color = new Color(209/255f, 1f, 0f, 1f);
            txtHighScore.text = "New HighScore: " + PlayerPrefs.GetInt("Highscore");
            txtScore.text = "Points: " + Contador.points;
        }
    }
}
