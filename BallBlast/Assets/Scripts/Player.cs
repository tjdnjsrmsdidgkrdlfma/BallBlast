using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    public float shot_cooltime;

    float horizontal;

    Rigidbody2D rigidbody2d;
    GameObject player_bullet_prefab;

    void Start()
    {
        Initialization();
        StartCoroutine(FireBullet());
    }

    void Initialization()
    {
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
        player_bullet_prefab = Resources.Load("Prefabs/PlayerBullet") as GameObject;
    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            GameObject player_bullet = MonoBehaviour.Instantiate(player_bullet_prefab, this.transform.position + Vector3.up, Quaternion.identity);
            player_bullet.GetComponent<PlayerBullet>().damage = 10;

            yield return new WaitForSeconds(shot_cooltime);
        }
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 move = new Vector2(horizontal, 0);

        rigidbody2d.velocity = move * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball") == true)
        {
            Debug.Log("GameOver");
            Destroy(this.gameObject);
        }
    }
}