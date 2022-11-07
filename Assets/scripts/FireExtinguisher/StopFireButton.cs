using UnityEngine;
using UnityEngine.EventSystems;
public class StopFireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject spray;
    public PowderLevel powderLevel;

    public void OnPointerDown(PointerEventData eventData)
    {
        spray.SetActive(true);
        powderLevel.isButtonHeld = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        spray.SetActive(false);
        powderLevel.isButtonHeld = false;
        powderLevel.StartRegeneration();
    }
}
