using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour {
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset lightingPreset;

    private float lastTimeOfDay = -1;
    [SerializeField, Range(0, 24)] private float timeOfDay;
    [SerializeField] private Vector3 camOffset;
    [SerializeField][Tooltip("In seconds")] private float dayCycle;

    private void Update() {
        if(lightingPreset == null) return;

        if(Application.isPlaying) {
            if(lastTimeOfDay > timeOfDay) {
                WaveManager.Instance.day++;
            }
            lastTimeOfDay = timeOfDay;
            timeOfDay += Time.deltaTime * (24/dayCycle);
            timeOfDay %= 24f;
            UpdateLighting(timeOfDay / 24f);
        } else {
            UpdateLighting(timeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent) {
        RenderSettings.ambientLight = lightingPreset.ambientColor.Evaluate(timePercent);
        if(timePercent < 0.5f) {
            RenderSettings.fogEndDistance = 50f + timePercent * timePercent * 200f;
        } else {
            RenderSettings.fogEndDistance = 50f + (1f - timePercent) * (1f - timePercent) * 200f;
        }

        if(directionalLight != null) {
            directionalLight.color = lightingPreset.directionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - camOffset.x, camOffset.y, camOffset.z));
        }
    }

    private void OnValidate() {
        if(directionalLight != null) return;

        if(RenderSettings.sun != null)
            directionalLight = RenderSettings.sun;
        else {
            Light[] lights = FindObjectsOfType<Light>();
            foreach(Light light in lights)
                if(light.type == LightType.Directional)
                    directionalLight = light;
        }
    }
}
