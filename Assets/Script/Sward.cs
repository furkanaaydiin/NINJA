using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sward : MonoBehaviour
{
    public GameObject cutPrefab;
    public float cutLifeTime;
    private bool divide;
    private Vector2 swipeStart;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            divide = true;
            swipeStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButtonUp(0) && divide)
        { 
           divide = false;
           cutSpawner(); 

         }

        
    }

    void cutSpawner()
    {
        Vector2 swipeEnd = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        GameObject  cutistance = Instantiate(cutPrefab,swipeStart , Quaternion.identity);

        cutistance.GetComponent<LineRenderer>().SetPosition(0,swipeStart);
        cutistance.GetComponent<LineRenderer>().SetPosition(1,swipeEnd );

        Vector2[] colliderPoints = new Vector2[2];
        colliderPoints[0] = Vector2.zero;
        colliderPoints[1] = swipeEnd - swipeStart;
        cutistance.GetComponent<EdgeCollider2D>().points = colliderPoints;
        Destroy(cutistance,cutLifeTime); 
     }
}
