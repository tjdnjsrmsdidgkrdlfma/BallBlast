using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage;

    int speed;

    Rigidbody2D rigidbody2d;

    void Start()
    {
        speed = 25;
        rigidbody2d = GetComponent<Rigidbody2D>();
        MoveBullet();
    }

    void MoveBullet()
    {
        rigidbody2d.velocity = Vector2.up * speed;
    }
}