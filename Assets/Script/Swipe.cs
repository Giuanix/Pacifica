using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    int index;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(index);

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if( endTouchPosition.x < startTouchPosition.x)
            {
                index++;
            }
            if (endTouchPosition.x > startTouchPosition.x)
            {
                index--;
            }
        }
    }
}
