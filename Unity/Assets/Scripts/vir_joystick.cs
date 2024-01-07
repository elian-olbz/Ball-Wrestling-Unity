using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class vir_joystick : MonoBehaviour,IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bg_image;
    private Image joystick_img;
    private Vector3 InputVector;

    private void Start()
    {
        bg_image = GetComponent<Image>();
        joystick_img = transform.GetChild(0).GetComponent<Image>();
    }


    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bg_image.rectTransform,
            ped.position, ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x / bg_image.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bg_image.rectTransform.sizeDelta.y);

            InputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized:InputVector;

             joystick_img.rectTransform.anchoredPosition =
                new Vector3(InputVector.x * (bg_image.rectTransform.sizeDelta.x / 3.5f),
                InputVector.z * (bg_image.rectTransform.sizeDelta.y / 3.5f));           
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        InputVector = Vector3.zero;
        joystick_img.rectTransform.anchoredPosition = Vector3.zero;
    }
    public float Horizontal()
    {
        if (InputVector.x != 0)
        {
            return InputVector.x;
        }
        else
            return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (InputVector.z != 0)
        {
            return InputVector.z;
        }
        else
            return Input.GetAxis("Vertical");

    }
}
