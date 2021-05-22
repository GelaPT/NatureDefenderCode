using UnityEngine;

public class UIManager : Singleton<UIManager> {
    [SerializeField] private Camera UICamera;
    [SerializeField] private GameObject UIObject;
    [SerializeField] private GameObject[] disabledObjects;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject pauseCanvas;
    public GameObject lostCanvas;

    private void Start() {
        Time.timeScale = 0.0f;
    }

    private void Update() {
        float unscaledTime = Time.unscaledTime / 3f;
        UICamera.transform.position = new Vector3(Mathf.Cos(unscaledTime) * 230, 230, Mathf.Sin(unscaledTime) * 230);
        UICamera.transform.LookAt(transform.position);
    }

    public void StartGame() {
        gameObject.SetActive(false);
        UIObject.SetActive(false);
        Time.timeScale = 1.0f;
        RenderSettings.fog = true;
        pauseMenu.isPaused = false;
        pauseCanvas.SetActive(false);
        foreach(GameObject disabledObject in disabledObjects) {
            disabledObject.SetActive(true);
        }
    }
}
