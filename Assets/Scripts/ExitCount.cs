using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitCount : MonoBehaviour
{
    [SerializeField] GameObject GOPanel;
    public static int ballExitCount;
    

   
    private void Awake()
    {
        ballExitCount = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballExitCount += 1;
            StartCoroutine(GO());
        }
    }

    IEnumerator GO()
    {
        yield return new WaitForSeconds(2f);
        GOPanel.SetActive(true);
    }
    
}
