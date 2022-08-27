using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int hit_point;
    public int split_time;

    int max_hit_point;

    GameObject ball_hit_point;
    GameObject ball_prefab;

    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        max_hit_point = hit_point;

        ball_hit_point = this.transform.Find("BallHitPoint").gameObject;
        ball_prefab = Resources.Load("Prefabs/Ball") as GameObject;

        transform.localScale = new Vector2(1 + 0.5f * split_time, 1 + 0.5f * split_time); //1 1.5 2

        ball_hit_point.GetComponent<TextMeshPro>().text = hit_point.ToString();
    }

    void Update()
    {
        if (hit_point <= 0)
        {
            if (split_time > 0)
            {
                Vector2 temp = this.transform.position;

                GameObject child_ball_left = Instantiate(ball_prefab, new Vector2(temp.x - 1, temp.y), Quaternion.identity);
                child_ball_left.GetComponent<Ball>().hit_point = max_hit_point == 1 ? 1 : max_hit_point / 2; //0이 되지 않게 하는 코드
                child_ball_left.GetComponent<Ball>().split_time = split_time - 1;
                child_ball_left.GetComponent<Ball>().GetComponent<Rigidbody2D>().AddForce(Vector2.right * -100);

                GameObject child_ball_right = Instantiate(ball_prefab, new Vector2(temp.x + 1, temp.y), Quaternion.identity);
                child_ball_right.GetComponent<Ball>().hit_point = max_hit_point == 1 ? 1 : max_hit_point / 2; //0이 되지 않게 하는 코드
                child_ball_right.GetComponent<Ball>().split_time = split_time - 1;
                child_ball_right.GetComponent<Ball>().GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
            }
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet") == true)
        {
            hit_point -= other.gameObject.GetComponent<PlayerBullet>().damage;
            ball_hit_point.GetComponent<TextMeshPro>().text = hit_point.ToString();
            Destroy(other.gameObject);
        }
    }
}