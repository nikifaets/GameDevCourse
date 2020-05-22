using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntegerController : MonoBehaviour
{

    public int value = 100;
    private Texture2D[] digits = new Texture2D[10];

    void Start(){

        string name = "winum";

        for(int i=0; i<10; i++){

            digits[i] = Resources.Load("Numbers/" + name + i.ToString()) as Texture2D;
            Debug.Log(Resources.Load("Numbers/" + name + i.ToString()) as Texture2D);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Render();
    }

    void SetValue(int value){

        this.value = value;
    }

    void Render(){

        int ones = value % 10;
        int rest = value / 10;
        int tens = rest > 0 ? rest % 10 : -1;
        rest = rest / 10;
        int hundreds = rest > 0 ? rest % 10 : -1;

        PickTexture(ones, "Ones");
        PickTexture(tens, "Tens");
        PickTexture(hundreds, "Hundreds");

    }

    void PickTexture(int value, string node){

        if(value < 0){

            transform.Find(node).gameObject.SetActive(false);
            return;
        }

        transform.Find(node).gameObject.SetActive(true);

        RawImage img = transform.Find(node).GetComponent<RawImage>();
        img.texture = digits[value];
    }
}
