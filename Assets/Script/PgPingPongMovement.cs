using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PgPingPongMovement : MonoBehaviour
{
    //variabile che tine traccia se vi è un tocco o no sullo schermo
    private bool isBeingHeld = false;
    void Update()
    {
        /*se il tocco avviene
        1) viene creato un vector 3 di nome mousePos
        2) la posizione del mousePos è uguale al punto toccato sullo schermo
        3) tale punto deve essere nel punto inquadrato dalla camera
        4) l'oggetto toccato avrà la stessa position di quella che tocchiamo su schermo */
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = new Vector3(Input.mousePosition.x, 300f, 0);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
    private void OnMouseDown()
    {
        //quando un oggetto viene cliccato la sua posizione diventerà unguale a quella del punto toccato...
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = new Vector3(Input.mousePosition.x, 300f, 0);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isBeingHeld = true;
        }
    }
    private void OnMouseUp()
    {
        //...fino a quando non viene rilasciato
        isBeingHeld = false;
    }
}

