using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public Camera cam;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
    private bool multiTouch = false;
    public float groundZ = 0;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            multiTouch = false;
            ////Orthographic code
            //touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Perspective Code
            touchStart = GetWorldPosition(groundZ);

        }
        
        if (Input.touchCount == 2)
        {
            multiTouch = true;
            Touch touchzero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector3 touchZeroPrevPos = touchzero.position - touchzero.deltaPosition;
            Vector3 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitutde = (touchzero.position - touchOne.position).magnitude;

            float difference = currentMagnitutde - prevMagnitude;

            zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0) && multiTouch == false)
        {
            ////orthographic code
            //Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Camera.main.transform.position += direction;
            
            //Perspective code
            Vector3 direction = touchStart - GetWorldPosition(groundZ);
            Camera.main.transform.position += direction;
        }

        zoom(Input.GetAxis("Mouse ScrollWheel"));

      }

    void zoom(float increment)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, zoomOutMin, zoomOutMax);

        //Orthographic Code
        //Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePOS = cam.ScreenPointToRay(Input.mousePosition); ;
        Plane ground = new Plane(Vector3.up, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePOS, out distance);
        return mousePOS.GetPoint(distance);
    }
}
