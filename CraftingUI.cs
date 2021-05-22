using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    [SerializeField] private GameObject craftingMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            craftingMenu.SetActive(!craftingMenu.activeInHierarchy);
            Cursor.lockState = craftingMenu.activeInHierarchy ? CursorLockMode.Confined : CursorLockMode.Locked;
        }
    }
}
