using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    private Animator animatorPlayer;
    private GameObject player;
    [SerializeField] private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        animatorPlayer = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
