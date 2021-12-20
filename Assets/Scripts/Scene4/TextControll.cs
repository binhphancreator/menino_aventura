using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextControll : MonoBehaviour
{
    // Start is called before the first frame update
    Color32 c0 = new Color(255,0,0,255);
    Color32 c1 = new Color(0,255,0,255);
    TextMeshPro tmp;
    string textMesh ="";
    int i = 0;
    int winCondition = 0;
    System.Random random = new System.Random();
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(i == tmp.text.Length){
            generateString();
            i = 0;
            textMesh = "";
            winCondition += 1;
        }

        if(winCondition == 3){
            Debug.Log("win roi em ei");
        }
    }

    void changeColor(bool status){
        int step = i;
        Color32 c;
        if (status == true){
            c = c1;
            i = step + 1; 
        } else {
            c = c0;
        }
        // tmp.ForceMeshUpdate();
       TMP_TextInfo teinfo = tmp.textInfo;
       Color32[] newVertColors;
       int materialIndex = teinfo.characterInfo[step].materialReferenceIndex;
       newVertColors = teinfo.meshInfo[materialIndex].colors32;
       int vertexIndex = teinfo.characterInfo[step].vertexIndex;
       newVertColors[vertexIndex + 0] = c;
       newVertColors[vertexIndex + 1] = c;
       newVertColors[vertexIndex + 2] = c;
       newVertColors[vertexIndex + 3] = c;
       tmp.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32); 
    }

    public void checkWord(string s){
        string a = Char.ToString(tmp.text[i]);
        if(a.ToLower().Equals(s.ToLower()) == true){
            changeColor(true);
        } else {
            changeColor(false);
        }
    }

    void generateString(){
        for (int j = 0; j < tmp.text.Length + 2; j++){
            textMesh += ((char)(random.Next(1, 26) + 96)).ToString().ToLower();
        }
        tmp.text = textMesh;
    }
}
