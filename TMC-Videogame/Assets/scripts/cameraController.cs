using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Vector2 angle = new Vector2(90 * Mathf.Deg2Rad,0);
    public Transform follow;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");    
        float vertical = Input.GetAxis("Mouse Y");
        if (horizontal != 0)
        {
            angle.x += horizontal * Mathf.Deg2Rad;
        }
        if (vertical != 0)
        {
            angle.y += vertical * Mathf.Deg2Rad;
            angle.y = Mathf.Clamp(angle.y,-80 * Mathf.Deg2Rad,80);
        }
    }
    private void LateUpdate()
    {
        Vector3 orbit = new Vector3(
            Mathf.Cos(angle.x) * Mathf.Cos(angle.y),
            -Mathf.Sign(angle.y),
            -Mathf.Sin(angle.x) * Mathf.Cos(angle.y)
            );
        transform.position = follow.position + orbit * distance;
        transform.rotation = Quaternion.LookRotation(follow.position-transform.position);
    }
}
