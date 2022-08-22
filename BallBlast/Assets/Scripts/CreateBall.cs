using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    float spawn_cooltime = 1f;

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
            MakeRandomCoordinate();
            SpawnBall();

            yield return new WaitForSeconds(spawn_cooltime);
        }
    }

    void MakeRandomCoordinate()
    {
        create_position.x = Random.Range(-3.0f, 3.0f);
    }

    void SpawnBall()
    {
        GameObject ball = MonoBehaviour.Instantiate(ball_prefab, create_position, Quaternion.identity);
    }
}
