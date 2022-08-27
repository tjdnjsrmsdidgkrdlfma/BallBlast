using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWall : MonoBehaviour
{
    float push_power;
    float bounce_power;
    int index;

    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        push_power = 100;
        bounce_power = 300;
        if (gameObject.name == "LeftWall")
        {
            index = 0;
        }
        else if (gameObject.name == "RightWall")
        {
            index = 1;
        }
        else if (gameObject.name == "BottomWall")
        {
            index = 2;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball") == true)
        {
            switch(index)
            {
                case 0:
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * push_power);
                    break;
                case 1:
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * push_power * -1);
                    break;
                case 2:
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce_power);
                    break;
            }
        }
    }
}
