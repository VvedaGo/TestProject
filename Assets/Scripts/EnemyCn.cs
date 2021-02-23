using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCn : MonoBehaviour
{
    float speed = 0.01f;

    private void FixedUpdate()
    {
        float ballPos = GameObject.FindGameObjectWithTag("Ball").transform.position.x;

        bool move = GameObject.Find("TouchScreen").GetComponent<TouchControl>().ballReady; //если мяч не брошен, стоит на месте

        if (transform.position.x < ballPos && !move)
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        else if (transform.position.x > ballPos && !move)
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
    }

    public void SetDifficulty(int dif)
    {
        speed *= dif;
    }
}
