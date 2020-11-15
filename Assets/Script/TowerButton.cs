﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private int price;

    [SerializeField]
    private Text priceText;

    public Sprite Sprite
    {
        get{ 
            return sprite;
        }        
    }

    public GameObject TowerPrefab
    {
        get
        {
            return towerPrefab;
        }
    }

    public int Price
    {
        get
        {
            return price;
        }
    
    }

    private void Start()
    {
        priceText.text = "$" + price;

    }
}
