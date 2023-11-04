using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToroScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float rangoDeAlerta;
    public float rangoDeAtaque;
    public LayerMask capaDelJugador;
    private bool estarAlerta;
    private bool atacar;
    public Transform player;
    public float velocidad;
    public float velocidadDeAtaque;
    public lifeControler controladorVida;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position,rangoDeAlerta,capaDelJugador);
        atacar = Physics.CheckSphere(transform.position, rangoDeAtaque, capaDelJugador);
        Vector3 ultimaPosicionConocida = Vector3.zero;
        Debug.Log(estarAlerta);
        if (estarAlerta == true) 
        {
            if (atacar == true)
            {
                StartCoroutine(AtacarDespuesDeEspera(ultimaPosicionConocida));
                Debug.Log("Ataca al jugador");
            }
            else
            {
                Vector3 vectorMovimiento = new Vector3(player.position.x, transform.position.y, player.position.z);
                transform.LookAt(vectorMovimiento);
                transform.position = Vector3.MoveTowards(transform.position, vectorMovimiento, velocidad * Time.deltaTime);
                Debug.Log("El jugador esta cerca");

                // Guardar la última posición conocida
                ultimaPosicionConocida = vectorMovimiento;
            }
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,rangoDeAlerta);
        Gizmos.DrawWireSphere(transform.position,rangoDeAtaque);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            controladorVida.quitarVida(20);
        }
    }
    IEnumerator AtacarDespuesDeEspera(Vector3 posicionAtaque)
    {
        yield return new WaitForSeconds(1f); // Espera 1 segundo

        Debug.Log("Ataca al jugador en posición: " + posicionAtaque);

        transform.LookAt(posicionAtaque);
        transform.position = Vector3.MoveTowards(transform.position, posicionAtaque, velocidad * Time.deltaTime);
    }
}
