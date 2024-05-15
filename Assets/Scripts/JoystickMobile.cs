using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMobile : MonoBehaviour
{

    public float Dist;
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;
    public int playerX;
    public int playerY;

    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
        playerX = 0;
        playerY = 0;
    }

    public void PointerDown()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 point = Camera.main.ScreenToWorldPoint(touch.position);
        joystick.transform.position = point;
        joystickBG.transform.position = point;
        joystickTouchPos = point;
    }



    public void Drag(BaseEventData baseEventData)
    {
       
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = Camera.main.ScreenToWorldPoint(pointerEventData.position);
       
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < Dist)
        {
            joystick.transform.position = dragPos;
        }

        else
        {
            joystick.transform.position = joystickTouchPos + (joystickVec/100) * joystickRadius; 
        }

        if(joystick.transform.position.x > joystickBG.transform.position.x)
        {
            playerX = 1;

        }
        else if(joystick.transform.position.x < joystickBG.transform.position.x)
        {
            playerX = -1;
        }

        if (joystick.transform.position.y > joystickBG.transform.position.y)
        {
            playerY = 1;
        }
        else if (joystick.transform.position.y < joystickBG.transform.position.y)
        {
            playerY = -1;
        }


      //  Debug.Log(playerX);
      //  Debug.Log(playerY);

    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
        playerX = 0;
        playerY = 0;
       // Debug.Log(playerX);
       // Debug.Log(playerY);
    }


}
