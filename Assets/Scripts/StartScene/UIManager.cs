using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Minigame2Panel;

    public  void ShowMinigame2(bool isShow){
        if(Minigame2Panel){
            Minigame2Panel.SetActive(isShow);
        }
    }

}
