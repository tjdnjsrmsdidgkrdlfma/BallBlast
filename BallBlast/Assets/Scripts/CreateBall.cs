using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    public float spawn_cooltime;

    float random_horizontal_force;

    Vector2 create_position = new Vector2(0, 9);
    GameObject ball_prefab;

    void Start()
    {
        ball_prefab = Resources.Load("Prefabs/Ball") as GameObject;
        StartCoroutine(CreateBall_());
    }

    IEnumerator CreateBall_()
    {
        while (true)
        {
            MakeRandomValue();
            SpawnBall();

            yield return new WaitForSeconds(spawn_cooltime);
        }
    }

    void MakeRandomValue()
    {
        create_position.x = Random.Range(-3f, 3f);
        random_horizontal_force = Random.Range(-100f, 100f);
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(ball_prefab, create_position, Quaternion.identity);
        ball.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * random_horizontal_force);
    }
}
