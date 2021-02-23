using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class ExitBt : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Application.Quit();
    }
}
