using UnityEngine;

public class StoneManager : MonoBehaviour {
    private float timeDead;
    private GameObject metal;
    private Transform player;
    private int resources;
    private int health;

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
        timeDead = ResourceManager.Instance.timeDead;
        metal = ResourceManager.Instance.metalPrefab;
        health = ResourceManager.Instance.stoneHealth;
        player = GameManager.Instance.player.transform;
        resources = ResourceManager.Instance.metal;
    }

    private void RespawnStone() {
        health = ResourceManager.Instance.stoneHealth;
        gameObject.name = "Stone(" + health + ")";
        gameObject.SetActive(true);
    }

    public void TakeDamage() {
        if(health == 0) return;
        health--;
        gameObject.name = "Rock(" + health + ")";
        if(health == 0) {
            gameObject.SetActive(false);
            for(int i = 0; i < resources; i++) {
                GameObject woodInstance = Instantiate(metal, transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(1f, 3f), Random.Range(-2f, 2f)), Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
                woodInstance.name = metal.name;
            }
        }
        Debug.Log("damageRock");
    }

    private void OnDisable() {
        Invoke("RespawnStone", timeDead);
    }
}
