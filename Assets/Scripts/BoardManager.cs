﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public static BoardManager shareInstace;
    public List<Sprite> prefab = new List<Sprite>();
    public GameObject currentCandy;
    public int xSize, ySize;

    public bool isShifting { get; set; }

    private Candy selectedCandy; 

    private GameObject[,] candies;
    // Start is called before the first frame update
    void Start()
    {
        if (shareInstace == null)
        {
            shareInstace = this;
        }else
        {
            Destroy(gameObject);
        }
        Vector2 offset = currentCandy.GetComponent<BoxCollider2D>().size;
        CreateInitialBoard(offset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateInitialBoard(Vector2 offset){
        candies = new GameObject[xSize, ySize];

        float startX = this.transform.position.x;
        float startY = this.transform.position.y;

        int idx = -1;
        
        for (int x = 0; x < xSize ; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GameObject newCandy = Instantiate(currentCandy, new Vector3(startX + (offset.x * x), startY + (offset.y * y),
                                0), currentCandy.transform.rotation);
                newCandy.name = string.Format("Candy[{0}][{1}]", x, y);
                

                do {
                    idx = Random.Range(0, prefab.Count);
                } while (
                        (x > 0 && idx == candies[x-1, y].GetComponent<Candy>().id) ||
                        (y > 0 && idx == candies[x, y-1].GetComponent<Candy>().id)
                );
                Sprite sprite = prefab[idx];
                newCandy.GetComponent<SpriteRenderer>().sprite = sprite;
                newCandy.GetComponent<Candy>().id = idx;
                newCandy.transform.parent = this.transform;
                candies[x, y] = newCandy;
            }
        }
    }



}
