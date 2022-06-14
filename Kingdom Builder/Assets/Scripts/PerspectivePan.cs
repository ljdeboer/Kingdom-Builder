using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectivePan : MonoBehaviour
{
    private Vector3 touchStart;
    public Camera cam;
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
           
            touchStart = GetWorldPostition(groundZ);
            
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - GetWorldPostition(groundZ);
            Camera.main.transform.position += direction;
        }
    }
    private Vector3 GetWorldPostition(float z)
    {
        Ray mousePos= cam.ScreenPointToRay( Input.mousePosition );
        Plane ground = new Plane(Vector3.up, new Vector3(0,0,z ));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
}
