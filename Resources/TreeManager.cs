using UnityEngine;

public class TreeManager : MonoBehaviour {
    private float timeDead;
    private GameObject wood;
    private Transform player;
    private int resources;
    private int health;

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
        timeDead = ResourceManager.Instance.timeDead;
        wood = ResourceManager.Instance.woodPrefab;
        health = ResourceManager.Instance.treeHealth;
        player = GameManager.Instance.player.transform;
        resources = ResourceManager.Instance.wood;
    }

    private void RespawnTree() {
        health = ResourceManager.Instance.treeHealth;
        gameObject.name = "Tree(" + health + ")";
        gameObject.SetActive(true);
    }

    public void TakeDamage() {
        if(health == 0) return;
        health--;
        gameObject.name = "Tree(" + health + ")";
        if(health == 0) {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, player.eulerAngles.y, transform.localEulerAngles.z);
            animator.Play("Fall");
        }
        Debug.Log("damageTree");
    }

    public void ChopDown() {
        gameObject.SetActive(false);
        for(int i = 0; i < resources; i++) {
            GameObject woodInstance = Instantiate(wood, transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(1f, 3f), Random.Range(-2f, 2f)), Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            woodInstance.name = wood.name;
        }
    }

    private void OnDisable() {
        Invoke("RespawnTree", timeDead);
    }
}
