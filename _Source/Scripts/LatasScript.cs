using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class LatasScript : MonoBehaviour {

    public GameObject explosao;
    public RawImage hitMarker;
    Rigidbody rb;
    public AudioClip hitSound;
    GameObject currentCanvas;
    float baseSize;


    private void Awake()
    {
        baseSize = GetComponent<Transform>().localScale.x;
        rb = GetComponent<Rigidbody>();

        currentCanvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("bola"))
        {
            Contador.points += 250;
            HitmarkerSpawn();
            Handheld.Vibrate();
            Debug.Log("Antes "+ rb.useGravity);
            rb.useGravity = true;
            Debug.Log("Depois " + rb.useGravity);
        }

        if (collision.gameObject.CompareTag("Target"))
        {
            Contador.points += 100;
            rb.useGravity = true;
        }

        if (collision.gameObject.CompareTag("Lava"))
        {
            Contador.points += 500;
            gameObject.SetActive(false);
            GameObject explo = Instantiate(explosao, transform.position, transform.rotation) as GameObject;
            Destroy(explo, 4f);
            Destroy(this.gameObject, 4f);

        }
    }
    void HitmarkerSpawn()
    {
        RawImage hit = Instantiate(hitMarker) as RawImage;
        hit.transform.SetParent(currentCanvas.transform, false);
        Destroy(hit, 0.3f);
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
    }


    private void FixedUpdate()
    {
        float anim = baseSize + Mathf.Sin(Time.time * 8f) * baseSize / 7f;
        transform.localScale=Vector3.one*anim;
    }

}
