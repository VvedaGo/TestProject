using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<BallCn>().DestroyBall();
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<EnemyCounter>().BlockDeath();
        }
    }
}
