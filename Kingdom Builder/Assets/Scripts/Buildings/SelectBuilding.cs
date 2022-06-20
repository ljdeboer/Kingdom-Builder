using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBuilding : MonoBehaviour
{

    [SerializeField] GameObject Canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Add code so they have to double click a building to select it OR they can't be panning to select a building
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse is down");
            RaycastHit hitObject; new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitObject);

            if(hit)
            {
                Debug.Log("Hit");
                if(hitObject.transform.gameObject.tag == "Barracks")
                {
                    Debug.Log("Barracks Selected");
                    Instantiate<GameObject>(Canvas);

                }
                else
                {
                    Debug.Log("I Suck");
                }
            }
            else
            {
                Debug.Log("Barracks not selected");
            }
       
        }
    }
}
