using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public Camera myCam;
    private GameObject mainCamera;
    private float startXPos;
    private float startYPos;

    private bool isDragging = false;

    private void Awake()
    {
        
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        myCam = mainCamera.GetComponent<Camera>();
    }

    private void Update()
    {
        Debug.Log(GameOver.gameOver);
        if (isDragging)
        {
            DragObject();
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.position.x;
        startYPos = mousePos.y - transform.position.y;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        
        isDragging = false;
        GetComponent<Drag>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = transform.right*2;
    }

    public void DragObject()
    {
        Vector3 mousePos = Input.mousePosition;

        if(!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);
        transform.Translate(transform.right * Time.deltaTime * 10 , Space.World);
    }
}