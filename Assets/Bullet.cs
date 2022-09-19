using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    void Update()
    {
        transform.Translate(new Vector3(0, bulletSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("bye bye bullet");
        Destroy(this.gameObject);
    }
}
