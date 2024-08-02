using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    //Variabile che disattiva il drag quando non vi sono interazioni
    private bool isBeingHeld = false;

    void Update()
    {
        /*quando isBeingHeld è vero:
        1) Viene creato un vector3 di nome mousePos
        2) mousePos sarà uguale alla posizione corrente del punto cliccato
        3) tramite la camera viene rilevata la posizione nello schermo del punto cliccato
        4) se un oggetto viene cliccato la sua posizione diventerà uguale a quella del punto cliccato fino al rilascio*/
        if(isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
    private void OnMouseDown()
    {
        /*quando il dito clicca un punto:
        1) Viene creato un vector3 di nome mousePos
        2) mousePos sarà uguale alla posizione corrente del punto cliccato
        3) tramite la camera viene rilevata la posizione nello schermo del punto cliccato
        4) viene settato is BeingHeld a vero in modo da trascinare  gli oggetti */
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            
            isBeingHeld = true;
        } 
    }

    //quando non viene più cliccato un punto is BeingHeld vine esettata a falsa cosi da smettere di trascinare  eventuali oggetti
    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
