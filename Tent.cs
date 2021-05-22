using UnityEngine;

public class Tent : MonoBehaviour {
    [SerializeField] private GameObject lostCanvas;

    private void OnDestroy() {
        if(lostCanvas != null) lostCanvas.SetActive(true);
        Invoke("Quit", 5f);
    }

    private void Quit() {
        Application.Quit();
    }
}