using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Weapon {
    public GameObject prefab;
    public int WeaponId;
}
public class PlayerWeapons : Singleton<PlayerWeapons>
{
    public List<Weapon> weapons = new List<Weapon>();
    public Weapon WeaponSelected;

    private void Start()
    {
        WeaponSelected = weapons[0];
        weapons[0].prefab.SetActive(true);
        weapons[1].prefab.SetActive(false);
        weapons[2].prefab.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponSelected = weapons[0];
            weapons[0].prefab.SetActive(true);
            weapons[1].prefab.SetActive(false);
            weapons[2].prefab.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponSelected = weapons[1];
            weapons[0].prefab.SetActive(false);
            weapons[1].prefab.SetActive(true);
            weapons[2].prefab.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponSelected = weapons[2];
            weapons[0].prefab.SetActive(false);
            weapons[1].prefab.SetActive(false);
            weapons[2].prefab.SetActive(true);
        }
    }
}
