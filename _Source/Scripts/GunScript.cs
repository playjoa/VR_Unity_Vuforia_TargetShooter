using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {


    public Rigidbody bala;
    public GameObject explosion;
    public Animator animator;
    public AudioClip somTiro;
    public AudioSource emissor;
    public float tamanhoExplosao;
    float velocidade = 400f, timer;
    public bool carregando = false;
    // Use this for initialization
    void Start () {
		
	}
	
	public void Shoot()
    {
        if (!Contador.onGame)
            return;

        if (!carregando)
        {
            carregando = true;
            emissor.PlayOneShot(somTiro);
            
            animator.SetBool("Shoot", true);
            Rigidbody instance = (Rigidbody)Instantiate(bala, transform.position, transform.rotation);
            GameObject expl = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
            expl.transform.localScale = new Vector3(tamanhoExplosao, tamanhoExplosao, tamanhoExplosao);
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Destroy(expl, 2f);
            instance.AddForce(forward * velocidade);
            instance.transform.localScale = new Vector3(0.021f, 0.021f, 0.021f);
            Destroy(instance.gameObject, 3f);
            timer = 2f;

        }


    }

    private void FixedUpdate()
    {
        if (carregando)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                carregando = false;
                animator.SetBool("Shoot", false);
                carregando = false;
            }
        }
    }


}
