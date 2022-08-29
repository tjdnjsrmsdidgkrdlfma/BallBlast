using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    public int number_to_create;
    public float spawn_cooltime;

    int random_split_time;
    float random_horizontal_force;
    int round;
    bool create_ball_ended;
    bool all_bullet_destroyed;

    Vector2 create_position;
    GameObject ball_prefab;
    GameObject gamemanager;

    void Start()
    {
        ball_prefab = Resources.Load("Prefabs/Ball") as GameObject;
        gamemanager = GameObject.Find("GameManager");

        number_to_create = Random.Range(15, 21);
        create_position = new Vector2(0, 8.5f);
        round = gamemanager.GetComponent<GameManager>().round;
        create_ball_ended = false;
        all_bullet_destroyed = false;

        StartCoroutine(CreateBall_());
    }

    IEnumerator CreateBall_()
    {
        int i;

        for (i = 0; i < number_to_create; i++)
        {
            MakeRandomValue();
            SpawnBall();

            yield return new WaitForSeconds(spawn_cooltime);
        }

        create_ball_ended = true;
    }

    void MakeRandomValue()
    {
        create_position.x = Random.Range(-3f, 3f);
        random_split_time = Random.Range(0, 3);
        random_horizontal_force = Random.Range(-100f, 100f);
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(ball_prefab, create_position, Quaternion.identity);
        ball.gameObject.GetComponent<Ball>().hit_point = Random.Range(1, round * 5);
        ball.gameObject.GetComponent<Ball>().split_time = random_split_time;
        ball.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * random_horizontal_force);
    }

    void Update()
    {
        CheckRoundClear();
    }

    void CheckRoundClear()
    {
        if (create_ball_ended == true)
        {
            if (GameObject.Find("Ball(Clone)") == null)
            {
                all_bullet_destroyed = true;
            }
        }
    }
}
