using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenLoader : MonoBehaviour {

    public Slider sl;
    public Text txt;

	void Start () {
        StartCoroutine(CarregarCena());
	}

    IEnumerator CarregarCena()
    {
        AsyncOperation opperation =  SceneManager.LoadSceneAsync("Main");

        while (!opperation.isDone)
        {
            float progress = Mathf.Clamp01(opperation.progress / .9f);
            txt.text = progress * 100f+"% ";
            sl.value = progress;
            yield return null;
        }
    }
}
