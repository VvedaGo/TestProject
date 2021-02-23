using UnityEngine;

public class BallCn : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SideWall")
        {
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z); //изменение движения при столкновении со стеной
            
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            DestroyBall();
        }
        else if(collision.gameObject.tag == "BackWall")
        {
            DestroyBall();
        }
        
    }
    public void DestroyBall() //появление нового мяча при смерти
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>()
            .NewBall(Instantiate(gameObject, new Vector3(0, 0.9f, -8.8f), Quaternion.identity));

        Destroy(gameObject);
        GameObject.Find("TouchScreen").GetComponent<TouchControl>().BallReady();
    }
}
