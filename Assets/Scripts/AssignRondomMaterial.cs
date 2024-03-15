using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRondomMaterial : MonoBehaviour
{
    public Material[] materials; // an array of materials to choose from

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && materials != null && materials.Length > 0)
        {
            int index = Random.Range(0, materials.Length); // choose a random material index
            renderer.material = materials[index]; // assign the chosen material
        }
    }
}
