using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float gravedad = 9.8f;
    public GameObject Player;

    private lifeControler controladorVida;
    // Start is called before the first frame update
    void Start()
    {
        controladorVida = Player.GetComponent<lifeControler>();
        Physics.gravity *= gravedad;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
