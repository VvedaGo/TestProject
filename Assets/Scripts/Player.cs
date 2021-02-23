using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject ball;


    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public void PushBoll(Vector2 forse)//Толкаем мяч из TouchControl
    {
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(forse.x, 0, forse.y)); 
    }

    public void NewPlayerPos(Vector2 posicion) //передвигаем из TouchControl
    {
        Vector3 ballPos = ball.transform.position;
        transform.position = new Vector3(posicion.x + ballPos.x, 1, posicion.y + ballPos.z);
    }

    public void NewBall(GameObject newBall) //метот для присвоения 
    {
        ball = newBall;
    }
}
