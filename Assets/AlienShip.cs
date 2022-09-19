using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
