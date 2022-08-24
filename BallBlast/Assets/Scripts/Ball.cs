using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int hit_point;

    GameObject ball_hit_point;

    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        hit_point = Random.Range(0, 101);
        ball_hit_point = this.transform.Find("BallHitPoint").gameObject;
    }

    void Update()
    {
        ball_hit_point.GetComponent<TextMeshPro>().text = hit_point.ToString();
        if (hit_point <= 0)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet") == true)
        {
            hit_point -= other.gameObject.GetComponent<PlayerBullet>().damage;
            Destroy(other.gameObject);
        }

    }
}