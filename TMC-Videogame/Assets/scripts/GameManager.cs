using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject camara;
    public Vector3 positionCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        camara.transform.position = new Vector3(player.transform.position.x + positionCamera.x,player.transform.position.y + positionCamera.y,player.transform.position.z + positionCamera.z);
    }
    public void spawnPowerUp()
    {
       
    }
}
