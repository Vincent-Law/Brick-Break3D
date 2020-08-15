using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    //Plane objPlane;

    // Start is called before the first frame update
    //void Start()
    // {

    // }

    // Update is called once per frame

    //public LayerMask touchInputMask;
    void Update()
    {
        
        /*foreach(Touch touch in Input.touches)
        {
            Ray ray = camera.ScreenPoin--tToRay(touch.posistion);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit, touchInputMask))
            {
                game
            }
        }*/

       if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            
           
        
            //transform.position = touchPosition;
           //Vector3 paddlePlane = (0f,0f);

            Vector3 touchPosFar = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);
            Vector3 touchPosNear = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
            Vector3 touchPosF = Camera.main.ScreenToWorldPoint(touchPosFar)/2;
            Vector3 touchPosN = Camera.main.ScreenToWorldPoint(touchPosNear);
            Debug.DrawRay(touchPosN, touchPosF - touchPosN, Color.green);//debug ray
            print("The pos is" + touch.position);//console text
            touchPosF.z = -9.42f;
            touchPosF.x = touchPosF.x-1.5f;
            touchPosF.y = touchPosF.y + 1.25f;
            //objPlane = new Plane(Camera.main.transform.forward*-1,)
            if (touchPosF.x > 2.7)
                touchPosF.x = 2.7f;
            if (touchPosF.y > 4.6)
                touchPosF.y = 4.6f;
            if (touchPosF.y < -6.5)
                touchPosF.y = -6.4f;
            if (touchPosF.x < -2.7)
                touchPosF.x = -2.7f;
            transform.position = touchPosF;
            
            //touchPosition.z = -3.924f;

        }
       
    }
}
