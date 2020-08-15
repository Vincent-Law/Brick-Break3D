using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.touchCount > 0)
         {
             Touch touch = Input.GetTouch(0);
             Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
             Debug.DrawRay(touchPosition, Camera.main.transform.forward * 1000, Color.green);
         }
         */
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosFar = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);
            Vector3 touchPosNear = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
            Vector3 touchPosF = Camera.main.ScreenToWorldPoint(touchPosFar);
            Vector3 touchPosn = Camera.main.ScreenToWorldPoint(touchPosNear);
            Debug.DrawRay(touchPosn, touchPosF - touchPosn, Color.green);
        }
    }
}
