using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public GameObject fallObj;
    public float spawnTime;
    float m_spawnTime;
    GameManage gc;


    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameManage>();
        m_spawnTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(gc.IsGameOver()) {
                return;
            }
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0){
            SpawnEnemy ();
            
            m_spawnTime = spawnTime;
        }
            

    }
    public void SpawnEnemy ()
    {
        float randZpos = Random.Range(66f, 74f);
        Vector3 spawnPos = new Vector3(0, 25f, randZpos);
        
            Instantiate(fallObj, spawnPos, Quaternion.identity);
        
    }
}
