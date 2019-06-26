﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{

    private static Color selectedColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    private static Candy previousSelected = null;

    private SpriteRenderer spriteRenderer;
    private bool isSelected = false;

    public int id;
    
    private Vector2[] adjacentDirections = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SelectCandy()
    {
        isSelected = true;
        spriteRenderer.color = selectedColor;
        previousSelected = gameObject.GetComponent<Candy>();
    }

    private void DeselectCandy()
    {
        isSelected = false;
        spriteRenderer.color = Color.white;
        previousSelected = null;
    }

    private void OnMouseDown()
    {
        if(spriteRenderer.sprite == null || 
            BoardManager.shareInstace.isShifting)
        {
            return;
        }

        if (isSelected)
        {
            DeselectCandy();
        }
        else
        {
            if(previousSelected == null)
            {
                SelectCandy();
            }else
            {
                previousSelected.DeselectCandy();
                SelectCandy();
            }

            /* 
            else
            {
                 if (CanSwipe())
                {
                    SwapSprite(previousSelected);
                    previousSelected.FindAllMatches();
                    previousSelected.DeselectCandy();
                    FindAllMatches();

                    GUIManager.shareInstace.MoveCounter--;
                }
                else
                {
                    previousSelected.DeselectCandy();
                    SelectCandy();
                }
                */

            
        }
    }
}
