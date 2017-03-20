using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;


public class Bola : MonoBehaviour {


    private bool BolaEstaActiva;
    private Vector3 PosicionBola;
    private Vector2 FuerzaInicialBola;
    public GameObject Barra;
    private Rigidbody2D bola;
    public AudioClip Rebote;
    AudioSource audio;
    public AudioClip Poder;
    public AudioClip Muerte;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        //Crear la fuerza
        FuerzaInicialBola = new Vector2(50.0f, 100.0f);
        //Establecerlo inactivo
        BolaEstaActiva = false;
        //Posicion de la bola
        PosicionBola = transform.position;
        // Componente de rigidbody2D
        bola = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") == true) {
         //Comprobar si es la primera jugada
        if (!BolaEstaActiva) {
                //Resetear la fuerza
                bola.isKinematic = false;
                //Añadir una fuerza
                bola.AddForce(FuerzaInicialBola);
                //Establecer bola activa
                BolaEstaActiva = !BolaEstaActiva;
            
            }
        }

        if (!BolaEstaActiva && Barra != null){
            // conseguir y usar la posicion del jugador
            PosicionBola.x = Barra.transform.position.x;

            //Aplicar la posicion x del jugador a la bola
            transform.position = PosicionBola;
        }

        if (BolaEstaActiva && transform.position.y < -6) {
            BolaEstaActiva = !BolaEstaActiva;
            PosicionBola.x = Barra.transform.position.x;
            PosicionBola.y = -3.6f;
            transform.position = PosicionBola;
            FuerzaInicialBola = new Vector2(25.0f,50.0f);
            FuerzaInicialBola = new Vector2(-2.0f,-4.5f);
            audio.PlayOneShot(Muerte, 0.5f);






        }

	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (BolaEstaActiva)
        {
            audio.PlayOneShot(Rebote);
        }
    }

}



