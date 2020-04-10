using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{

    private Vector2 spawnDir = new Vector2(-0.5f, 1f);
    private GameObject MushroomPrefab;
    // Start is called before the first frame update
    void Start()
    {
        MushroomPrefab = Resources.Load<GameObject>("Mushroom");
        Debug.Log(MushroomPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        Debug.Log("hit");
        if(collision.gameObject.CompareTag("Player")){

            GameObject Mushroom = GameObject.Instantiate(MushroomPrefab, transform.position - new Vector3(1,0,0), transform.rotation);
            Debug.Log("spawn");
        }

    }
}


