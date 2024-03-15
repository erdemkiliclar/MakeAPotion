using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DissolvingController : MonoBehaviour
{
    //public SkinnedMeshRenderer skinnedMesh; If object is using skinnedMesh change this with down below
    public MeshRenderer skinnedMesh;

    //public VisualEffect VFXGraph;

    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;

    public Material[] skinnedMaterials;

    private void Start()
    {
        if (skinnedMesh != null)
        {
            skinnedMaterials = skinnedMesh.materials;
        }
    }
    public void Dissolve()
    {
        StartCoroutine(DissolveCo());
    }

    IEnumerator DissolveCo()
    {
        //if (VFXGraph !=null)
        //{
        //    VFXGraph.Play();
        //}
        if (skinnedMaterials.Length > 0)
        {
            float counter = 0;
            while (skinnedMaterials[0].GetFloat("_DissolveAmount") <1)
            {
                counter += dissolveRate*Time.deltaTime;
                for (int i = 0; i < skinnedMaterials.Length; i++)
                {
                    skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}
