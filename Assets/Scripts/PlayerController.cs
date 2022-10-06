using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] float movementSpeed;
    [SerializeField] float bulletBuffer;
    public float countdown;
    public GameObject bulletPrefab;

    void Update()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0);
        transform.Translate(movement);

        if (Input.GetButton("Fire") && countdown <= 0)
        {
            Debug.Log("Le Fire");
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            countdown = bulletBuffer;
        } else if(countdown > 0)
        {
            countdown -= .01f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadly"))
        {
            Destroy(this.gameObject);
        }
    }
}
