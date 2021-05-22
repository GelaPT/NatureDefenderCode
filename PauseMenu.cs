using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public bool isPaused = false;
    [SerializeField] private GameObject canvas;
    [SerializeField] private MouseLook mouseLook;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            canvas.SetActive(isPaused);
            Time.timeScale = isPaused ? 0.0f : 1.0f;
            Cursor.lockState = isPaused ? CursorLockMode.Confined : CursorLockMode.Locked;
        }
    }

    public void ChangeSensitivity(float value) {
        mouseLook.mouseSens = value;
    }

    public void Quit() {
        Application.Quit();
    }
}