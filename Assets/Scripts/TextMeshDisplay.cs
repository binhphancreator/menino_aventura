using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextMeshDisplay : MonoBehaviour
{
    TextMeshPro timeTextMesh;
    GameManage gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameManage>();
        timeTextMesh = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gc.timeRemaining > 0)
            {
                DisplayTime(gc.timeRemaining);
            }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeTextMesh.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
