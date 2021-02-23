using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    Vector2 touchPosition, pushVector;
    Player player;

    public bool ballReady = true;

    public GameObject arrowObj;
    GameObject newArrow;
    bool arrowReady = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void OnPointerDown(PointerEventData eventData) //запоминаем позицию нажатия
    {
        if(ballReady)
            touchPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ballReady) //мяч не на сцене
        {
            Vector2 secondPosicion = eventData.position; //позиция пальца
            pushVector = new Vector2(secondPosicion.x - touchPosition.x, secondPosicion.y - touchPosition.y); //направление свайпа

            float distanseToTouch = Vector3.Distance(touchPosition, secondPosicion); //длина свайпа 
            player.NewPlayerPos(pushVector.normalized * (Mathf.Sqrt(distanseToTouch) / 15)); //двигаеи игрока

            player.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(pushVector.y, pushVector.x) * Mathf.Rad2Deg,new Vector3(0,-1,0)); //оворачиваем игрока

            if (arrowReady) //если стрелка не на сцене
            {
                newArrow = Instantiate(arrowObj, player.transform.position, Quaternion.AngleAxis(90, new Vector3(1, 0, 0)));
                arrowReady = false;
            }

            Transform arrowTr = newArrow.GetComponent<Transform>();
            arrowTr.position = player.transform.position;                                       //крутим стрелку

            arrowTr.localScale = new Vector3(Mathf.Sqrt(distanseToTouch)/80, 0.1f, 1);
            arrowTr.transform.rotation =  Quaternion.Euler(90, player.transform.eulerAngles.y, 0);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Destroy(newArrow);
        if (ballReady)
        {
            ballReady = false;
            player.PushBoll(pushVector);
        }
    }

    public void BallReady() //спавн нового мяча 
    {
        ballReady = true;
        arrowReady = true;
    }
}
