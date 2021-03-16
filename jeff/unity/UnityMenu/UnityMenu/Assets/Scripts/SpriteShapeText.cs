using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteShapeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject textGo = new GameObject("myTextGO");
        //textGo.transform.SetParent(this.transform);
        //Text myText = textGo.AddComponent<Text>();
        //myText.text = "Ta-dah!";

        GameObject UItextGO = new GameObject("Text2");
        UItextGO.transform.SetParent(this.transform);

        RectTransform trans = UItextGO.AddComponent<RectTransform>();
        trans.anchoredPosition = this.transform.position;

        Text text = UItextGO.AddComponent<Text>();
        text.text = "Test";
        text.fontSize = 12;
        text.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
