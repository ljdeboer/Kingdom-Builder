using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    BuildingManager buildingManager;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BuildingManager");
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Barracks"))
        {
            buildingManager.canPlace = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Barracks"))
        {
            buildingManager.canPlace = true;
        }
    }
}
