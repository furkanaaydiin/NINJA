using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_Spawner : MonoBehaviour
{
    public GameObject prefeb;
    public float maxX;
    public float MinX;
    public float startTime;
     float time;
    public Sprite[] sprites;
     void Start()
    {
        
    }

   
    void Update()
    {
        if(time <= 0)
        {
            SpawnObject();
            time = startTime;
        }
        else{
            time -= Time.deltaTime;
        }
    }

    void SpawnObject()
    {
        GameObject NewPrefeb = Instantiate(prefeb);
        NewPrefeb.transform.position = new Vector2(
            Random.Range(maxX,MinX),
            transform.position.y
        );

        Sprite randomSprite= sprites[Random.Range(0,sprites.Length)];
        NewPrefeb.GetComponent<SpriteRenderer>().sprite = randomSprite; 
    }
}
