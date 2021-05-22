using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomResourceModelScript : MonoBehaviour
{
    [SerializeField] private GameObject[] meshes;

    //componentes
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        ChangeTreeModel();
    }

    void ChangeTreeModel()
    {
        int meshIndex = Random.Range(0, meshes.Length - 1);
        meshFilter.mesh = meshes[meshIndex].GetComponent<MeshFilter>().sharedMesh;
        Material[] mats = meshes[meshIndex].GetComponent<MeshRenderer>().sharedMaterials;
        meshCollider.sharedMesh = meshFilter.mesh;
        for (int i = 0; i < mats.Length - 1; i++)
        {
            meshRenderer.materials[i].CopyPropertiesFromMaterial(mats[i]);
        }
    }
}
