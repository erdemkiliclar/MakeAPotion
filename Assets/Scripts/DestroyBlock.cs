using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    private GameObject main;
    private GameObject GOPanel;

    private void Awake()
    {
        main= GameObject.FindGameObjectWithTag("Main");
        GOPanel = main.GetComponent<PanelControl>().goPanel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(GO());
        }
    }
    
    
    IEnumerator GO()
    {
        yield return new WaitForSeconds(2f);
        GOPanel.SetActive(true);
    }
}
