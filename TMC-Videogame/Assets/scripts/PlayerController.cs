using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float velocityMovment = 10f;
    public float rotationSpeed = 100f;
    private Animator animator;
    private float timePowerUp = 10f;
    private float timeRemaining;
    private bool isPowerUpActive = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        timeRemaining = timePowerUp;
    }
    void Update()
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

        if (Input.GetAxis("Fire1") != 0)
        {
            Debug.Log("Debe atacar" + Input.GetAxis("Fire1"));
            animator.SetBool("isAttack", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Power up");
            animator.SetBool("isPowerUp", true);
        }

        animator.SetFloat("velocityX", horizontal);
        animator.SetFloat("velocityY", vertical);

        if (isPowerUpActive)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log("Tiempo restante: " + Mathf.Round(timeRemaining));
            if (timeRemaining < 1)
            {
                isPowerUpActive = false;
                velocityMovment = 10f;
                animator.speed = 1f;
            }

        }
        else
        {
            timeRemaining = timePowerUp;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.collider.CompareTag("speedBoost"))
        {
            velocityMovment = 20f;
            animator.speed = 2f;
            isPowerUpActive = true;
            Destroy(collision.gameObject);
        }
    }

}
