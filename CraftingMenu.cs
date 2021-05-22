using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenu : MonoBehaviour
{
    TurretBuildController turretBuildController;
    PlayerInventory playerInventory;

    [SerializeField] private GameObject crossbow;
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject machine;
    void Start()
    {
        turretBuildController = GameObject.Find("TurretBuildController").GetComponent<TurretBuildController>();
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    public void BuyCannon()
    {
        if(playerInventory.Wood >= 10 && playerInventory.Metal >= 5)
        {
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            turretBuildController.placableObject = cannon;
            turretBuildController.isPlacing = true;
            turretBuildController.woodPrice = 10;
            turretBuildController.metalPrice = 5;
        }
    }

    public void BuyCrossbow()
    {
        if (playerInventory.Wood >= 15 && playerInventory.Metal >= 10)
        {
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            turretBuildController.placableObject = crossbow;
            turretBuildController.isPlacing = true;
            turretBuildController.woodPrice = 15;
            turretBuildController.metalPrice = 10;
        }
    }

    public void BuyMachine()
    {
        if (playerInventory.Wood >= 5 && playerInventory.Metal >= 5)
        {
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            turretBuildController.placableObject = machine;
            turretBuildController.isPlacing = true;
            turretBuildController.woodPrice = 5;
            turretBuildController.metalPrice = 5;
        }
    }
}
