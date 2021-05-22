using UnityEngine;

public class ResourceManager : Singleton<ResourceManager> {
    public float timeDead;
    public GameObject woodPrefab;
    public GameObject metalPrefab;
    public int wood = 5;
    public int metal = 5;
    public int treeHealth = 5;
    public int stoneHealth = 5;
}
