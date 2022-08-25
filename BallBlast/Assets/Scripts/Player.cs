using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    public float shot_cooltime;

    GameObject player_bullet_prefab;

    void Start()
    {
        Initialization();
        StartCoroutine(FireBullet());
    }

    void Initialization()
    {
        player_bullet_prefab = Resources.Load("Prefabs/PlayerBullet") as GameObject;
    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) == true)
            {
                GameObject player_bullet = Instantiate(player_bullet_prefab, this.transform.position + Vector3.up, Quaternion.identity);
                player_bullet.GetComponent<PlayerBullet>().damage = 10;
            }

            yield return new WaitForSeconds(shot_cooltime);
        }
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {

    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        this.transform.position = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -3.1f, 3.1f), -6.5f);
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