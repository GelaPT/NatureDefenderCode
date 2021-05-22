using UnityEngine;
using UnityEngine.AI;

public class WaveManager : Singleton<WaveManager> {
    [SerializeField] private GameObject enemyPrefab;
    public int lastFrameDay = 0;
    public int day = 0;
    [SerializeField] private LayerMask layerMask;

    private void Update() {
        if(lastFrameDay != day) {
            for(int i = 0; i < day * 5; i++) {
                Vector3 randomPoint = new Vector3(0, 0, 0) + Random.insideUnitSphere * 150;
                NavMeshHit hit;
                if(NavMesh.SamplePosition(randomPoint, out hit, 100.0f, NavMesh.AllAreas)) {
                    Instantiate(enemyPrefab, hit.position, Quaternion.identity);
                }
            }
        }

        lastFrameDay = day;
    }
}
