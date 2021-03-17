using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour {

    public GameObject explosao;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Destroy(this.gameObject);
           // GameObject explo = Instantiate(explosao, transform.position, transform.rotation) as GameObject;
           // Destroy(explo, 2f);

        }
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(this.gameObject);
        }
    }
}
