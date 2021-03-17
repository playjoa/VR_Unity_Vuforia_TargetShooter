using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour {

    public float timer;
    public static int points;
    Text txt;
    public Text pointsTxt;
    public static bool onGame = false;

    public GameObject barril, currentImageTarget, telaGameOver, essaTela;

    void Start()
    {
        txt = GetComponent<Text>();
    }

    public void ComecarJogo()
    {
        onGame = true;
        timer = 30f;
        points = 0;
    }

    public void RecomecarJogo()
    {
        timer = 30f;
        points = 0;
        DeletarBarrisAntigos();
        GameObject novosBarris = Instantiate(barril) as GameObject;
        novosBarris.transform.SetParent(currentImageTarget.transform, false);
        onGame = true;
    }

    public void RecomecarJogoDoGameOver()
    {
        telaGameOver.SetActive(false);
        essaTela.SetActive(true);
        RecomecarJogo();
    }

    

    void DeletarBarrisAntigos()
    {
        GameObject[] BarrisRestantes = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject barris in BarrisRestantes)
        {
            Destroy(barris);
        }

    }
    void GameOver()
    {
        onGame = false;
        txt.text = "OVER";
        telaGameOver.SetActive(true);
        essaTela.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (onGame)
        {
            timer -= Time.deltaTime;

            pointsTxt.text = "Points: " + points;
            if (timer >= 0)
            {
                txt.text = timer.ToString("0") + "s";
            }
            else
            {
                GameOver();
            }
        }
	}
}
