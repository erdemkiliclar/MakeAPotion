using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.Rendering;

public class CountControl : MonoBehaviour
{
    
    
    [SerializeField] private int ballCount;
    GameObject Main;
    
    public List<GameObject> ballList = new List<GameObject>();
    GameObject Balls;
    private GameObject victoryPart;

    private void Awake()
    {
        victoryPart = GameObject.FindGameObjectWithTag("VictoryPart");
        Balls = GameObject.FindGameObjectWithTag("Balls");
        Main = GameObject.FindGameObjectWithTag("Main");
        

        for (int i = 0; i < Balls.transform.childCount; i++)
        {
            ballList.Add(Balls.transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        ballCount = ballList.Count;
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            
            Main.GetComponent<DissolvingController>().Dissolve();
            ballCount--;
            Destroy(collision.gameObject);
            if (ballCount==0)
            {
                victoryPart.transform.position = this.transform.position;
                victoryPart.GetComponent<ParticleSystem>().Play();
                Main.GetComponent<PanelControl>().victoryPanel.SetActive(true);
                
            }
        }
    }
}
