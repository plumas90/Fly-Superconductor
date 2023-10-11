using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[] MapGroups;
    public GameObject nowMap;
    //public int moveSpeed=2;

    public float makeNextMapPositionX;
    //public float SetOffpositionX;

    private int maxMapcount;
    private int index = 0;
    void Start()
    {   
        maxMapcount = MapGroups.Length;
        MapGroups[index].SetActive(true);
        nowMap.transform.localPosition = new Vector2(-17.6f, -2f);
    }

    // Update is called once per frame
    void Update()
    {
            if (!GameManager.Instance.IsDead)
            {
            //nowMap.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);

                  if (nowMap.transform.localPosition.x <= makeNextMapPositionX)
                  {
                    MapGroups[index].SetActive(true);
                    nowMap = MapGroups[index];
                    index++;
                    if (index == maxMapcount)
                    {
                     index = 0;
                    }
                  }
            }

    }
    
}
