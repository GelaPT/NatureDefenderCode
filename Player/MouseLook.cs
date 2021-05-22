using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour {
    public float mouseSens = 100f;

    [SerializeField] private Transform playerBody;
    [SerializeField] private Text itemInfo;
    [SerializeField] private LayerMask itemMask;
    float xRotation = 0.0f;

    [SerializeField] private GameObject weapon;
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        RaycastHit hit;
        itemInfo.text = "";
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5.5f, itemMask)) {
            itemInfo.text = hit.collider.name;
            if(Input.GetKeyDown(KeyCode.Mouse0)) {
                if(hit.collider.TryGetComponent(out TreeManager tree) && PlayerWeapons.Instance.WeaponSelected.WeaponId == 1) {
                    weapon.GetComponent<Animator>().Play("AxeChop");
                    Debug.Log("1");
                    tree.TakeDamage();
                    Debug.Log("2");
                } else if(hit.collider.TryGetComponent(out StoneManager stone) && PlayerWeapons.Instance.WeaponSelected.WeaponId == 2) {
                    weapon.GetComponent<Animator>().Play("PickaxeChop");
                    stone.TakeDamage();
                }
            }
            if(Input.GetKeyDown(KeyCode.E)) {
                if(hit.collider.CompareTag("Wood")) {
                    PlayerInventory.Instance.Wood++;
                    Destroy(hit.collider.gameObject);
                } else if(hit.collider.CompareTag("Metal")) {
                    PlayerInventory.Instance.Metal++;
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && PlayerWeapons.Instance.WeaponSelected.WeaponId == 3) {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, itemMask)) {
                if(hit.collider.gameObject.CompareTag("Enemy")) {
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
