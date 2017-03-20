using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour {

    public int GolpesParaMatar;
    public int Puntos;
    private int NumerodeGolpes;
    public AudioClip Colision;
    AudioSource audio;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        NumerodeGolpes = 0;

		
	}
	
    void OnCollisionEnter2D (Collision2D collision) {

        if (collision.gameObject.tag == "Bola")
        {
            NumerodeGolpes++;

            if (NumerodeGolpes == GolpesParaMatar) {
                audio.PlayOneShot(Colision);
                //Destruye el objeto
                Destroy(this.gameObject);
            }
        }

    }


	// Update is called once per frame
	void Update () {
		
	}

}
