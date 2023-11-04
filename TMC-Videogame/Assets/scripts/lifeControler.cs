using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeControler : MonoBehaviour
{
    public Image lifeBar;
    public float life;
    public float lifeMax = 100f;
    // Start is called before the first frame update
    void Start()
    {
        life = lifeMax;
    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.fillAmount = life/lifeMax;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            quitarVida(20);
        }
    }
    public void quitarVida(float daño)
    {
        life -= daño;
        lifeBar.fillAmount = life / lifeMax;
        Debug.Log("La vida actual es : " + life);
    }
}
