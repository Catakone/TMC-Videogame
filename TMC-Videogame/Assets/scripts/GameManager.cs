using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject camara;
    public Vector3 positionCamera = new Vector3(0, 12, -7);
    public float gravedad = 9.8f;
    public TextMeshProUGUI txtJarrones;
    public TextMeshProUGUI txtPowerUpTime;
    private float puntos = 0;
    public float PutosObtenidos { get => puntos; set => puntos = value; }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravedad;
    }

    // Update is called once per frame
    void Update()
    {
        txtJarrones.text = "Puntos Obtenidos: " + puntos;
    }
    private void LateUpdate()
    {
        camara.transform.position = new Vector3(player.transform.position.x + positionCamera.x,player.transform.position.y + positionCamera.y,player.transform.position.z + positionCamera.z);
        
    }
    public void spawnPowerUp()
    {
       
    }
    public void powerUpTime(float time)
    {
        if (time > 1)
        {
            txtPowerUpTime.text = "SpeedBost " +  (int)time;
        }
        else
        {
            txtPowerUpTime.text = "";
        }
    }
}
