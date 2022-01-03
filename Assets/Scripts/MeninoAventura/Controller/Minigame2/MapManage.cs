using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManage : MonoBehaviour
{
    public int map;
    public GameObject map1,map2,map3;
    // Start is called before the first frame update
    void Start()
    {
        
        // map1.SetActive(true);
        selectMap();
    }

    void selectMap(){
        map = Random.Range(1, 3);
        switch (map)
        {
            case 1: 
                map1.SetActive(true);
                break;
            case 2: 
                map2.SetActive(true);
                break;
            case 3: 
                map3.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
