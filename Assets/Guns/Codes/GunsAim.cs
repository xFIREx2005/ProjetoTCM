using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsAim : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    void Aim() 
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        
         
        
    }
}
