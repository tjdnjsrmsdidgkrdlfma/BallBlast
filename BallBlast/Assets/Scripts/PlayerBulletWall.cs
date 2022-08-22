using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet") == true)
        {
            Destroy(other.gameObject);
        }
    }
}
