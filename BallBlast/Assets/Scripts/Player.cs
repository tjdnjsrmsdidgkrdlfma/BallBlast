using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    int bullet_damage;
    float bullet_fire_speed;

    GameObject player_bullet_prefab;
    GameObject gamemanager;

    void Start()
    {
        Initialization();
        StartCoroutine(FireBullet());
    }

    void Initialization()
    {
        player_bullet_prefab = Resources.Load("Prefabs/PlayerBullet") as GameObject;
        gamemanager = GameObject.Find("GameManager");

        bullet_damage = gamemanager.GetComponent<GameManager>().bullet_damage;
        bullet_fire_speed = gamemanager.GetComponent<GameManager>().bullet_fire_speed;
    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) == true)
            {
                GameObject player_bullet = Instantiate(player_bullet_prefab, this.transform.position + Vector3.up, Quaternion.identity);
                player_bullet.GetComponent<PlayerBullet>().damage = bullet_damage;
            }

            yield return new WaitForSeconds(bullet_fire_speed);
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        this.transform.position = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -3.1f, 3.1f), -6.5f); // -3.1 < x < 3.1 y = -6.5
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