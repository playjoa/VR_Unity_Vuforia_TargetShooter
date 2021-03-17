using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject btnVirtualShoot;

    GunScript gs;

	void Start () {
        btnVirtualShoot = GameObject.Find("btnVirtualAtirar");
        btnVirtualShoot.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        gs = FindObjectOfType<GunScript>();
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        gs.Shoot();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
    // Update is called once per frame
    void Update () {
		
	}
}
