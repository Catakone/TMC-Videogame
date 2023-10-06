using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //propiedades
    [SerializeField]private float velocityMovment = 10f;
    [SerializeField]private float rotationSpeed = 100f;
    [SerializeField]private GameObject Item;
    [SerializeField]private GameObject Disparo;
    private GameManager gameManager;
    private Animator animator;
    private float timePowerUp = 10f;
    private float timeRemaining;
    private bool isPowerUpActive = false;

    //getters y setters
    public float VelocityPlayer {get => velocityMovment;set => velocityMovment = value;}
    public bool statusPowerUp {get => isPowerUpActive;set => isPowerUpActive = value;}
    public float timeForPowerUp { get => timePowerUp;set => timePowerUp = value;}

    void Start()
    {
        animator = GetComponent<Animator>();
        timeRemaining = timePowerUp;
        gameManager = new GameManager();
    }
    void Update()
    {
        movePlayer();
        if (Input.GetAxis("Fire1") != 0)
        {
            attack();
        }
        powerUpTime(isPowerUpActive);
        Debug.Log("Estatus del power Up " + isPowerUpActive + "Tiempo del power Up " + timePowerUp + "Velocidad del personaje: " + velocityMovment);
    }

    private void attack()
    {
        Debug.Log("Debe atacar" + Input.GetAxis("Fire1"));
        animator.SetBool("isAttack", true);
    }

    public void movePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 movement = new Vector3(horizontal, 0, vertical);
            transform.Translate(movement * velocityMovment * Time.deltaTime, Space.World);
            if (movement != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement.normalized);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                animator.SetBool("isPowerUp", false);
                animator.SetBool("isAttack", false);
            }

        }
        animator.SetFloat("velocityX", horizontal);
        animator.SetFloat("velocityY", vertical);
    }
    public void powerUpTime(bool statusPowerUp)
    {
        if (statusPowerUp)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log("Tiempo restante: " + Mathf.Round(timeRemaining));
            if (timeRemaining < 1)
            {
                this.isPowerUpActive = false;
                velocityMovment = 10f;
                animator.speed = 1f;
            }

        }
        else
        {
            timeRemaining = timePowerUp;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("punto"))
        {
            gameManager.PutosObtenidos ++;
            Destroy(collision.gameObject);
        }
    }
}
