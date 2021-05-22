using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBuildController : MonoBehaviour
{
    public GameObject placableObject;

    [SerializeField] private Camera playerCamera;

    public bool isPlacing = false;

    private GameObject currentPlacableObject;
    
    public int woodPrice;
    public int metalPrice;

    // Update is called once per frame
    void Update()
    {
        HandleNewObject();

        if(currentPlacableObject != null)
        {
            MoveCurrentPlacableObject();
            if(Input.GetKeyDown(KeyCode.Mouse0)) {
                isPlacing = false;
                currentPlacableObject = null;
                PlayerInventory.Instance.Wood -= woodPrice;
                PlayerInventory.Instance.Metal -= metalPrice;
            }
        }
    }

    private void MoveCurrentPlacableObject()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, 100.0f, 8))
        {
            currentPlacableObject.transform.position = hitInfo.point;
        }
    }

    void HandleNewObject()
    {
        if (isPlacing)
        {
            if(currentPlacableObject == null)
            {
                currentPlacableObject = Instantiate(placableObject);
            }
        }
    }
}
