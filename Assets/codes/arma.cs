using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StateGame { GAMEPLAY,PAUSE}


public class arma : MonoBehaviour
{

    private Rigidbody2D rgArma;
    public GameObject perdeu;
    public StateGame estado;
    public ParticleSystem[] sangue;

    // Start is called before the first frame update
    void Start()
    {
        rgArma = GetComponent<Rigidbody2D>();
        perdeu.SetActive(false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            rgArma.gravityScale = 50;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Player")
        {
            perdeu.SetActive(true);
            Destroy(col.gameObject);
            Time.timeScale=0;
            
            foreach (ParticleSystem o in sangue )
            {
                o.Play();
            }
            StartCoroutine("pausa");
            estado = StateGame.PAUSE;
        }
    }


    IEnumerator pausa()
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(2f);
    }

}
