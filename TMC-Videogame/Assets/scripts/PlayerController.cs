using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //propiedades
    [SerializeField]private float velocityMovment = 10f;
    [SerializeField]private float rotationSpeed = 100f;
    private Animator animator;

    //getters y setters

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        movePlayer();
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
}
