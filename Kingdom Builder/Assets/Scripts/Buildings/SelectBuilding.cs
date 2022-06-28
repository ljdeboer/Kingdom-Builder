using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBuilding : MonoBehaviour
{

    [SerializeField] GameObject BarracksCanvas;
    private float firstClickTime, timeBetweenClicks;
    private bool coroutineAllowed;
    private int clickCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        firstClickTime = 0f;
        timeBetweenClicks = 0.2f;
        clickCounter = 0;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            clickCounter += 1;
        }
        if (clickCounter == 1 && coroutineAllowed)
        {
            firstClickTime = Time.time;
            StartCoroutine(DoubleClickDetection());
        }
        //Add code so they have to double click a building to select it OR they can't be panning to select a building
        //if(Input.GetMouseButton(0))
        //{
        //    Debug.Log("mouse is down");
        //    RaycastHit hitObject; new RaycastHit();
        //    bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitObject);

        //    if(hit)
        //    {
        //        Debug.Log("Hit");
        //        if(hitObject.transform.gameObject.tag == "Barracks")
        //        {
        //            Debug.Log("Barracks Selected");
        //            Instantiate<GameObject>(Canvas);

        //        }
        //        else
        //        {
        //            Debug.Log("I Suck");
        //        }
        //    }
        //    else
        //    {
        //        Debug.Log("Barracks not selected");
        //    }
       
        //}
    }
    private IEnumerator DoubleClickDetection()
    {
        coroutineAllowed = false;
        while(Time.time < firstClickTime + timeBetweenClicks)
        {
            if (clickCounter == 2)
            {                
                    Debug.Log("mouse is down");
                    RaycastHit hitObject; new RaycastHit();
                    bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitObject);

                    if (hit)
                    {
                        Debug.Log("Hit");
                        if (hitObject.transform.gameObject.tag == "Barracks")
                        {
                            Debug.Log("Barracks Selected");
                            Instantiate<GameObject>(BarracksCanvas);

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
            yield return new WaitForEndOfFrame();                        
        }

        clickCounter = 0;
        firstClickTime = 0f;
        coroutineAllowed = true;
    }
}
