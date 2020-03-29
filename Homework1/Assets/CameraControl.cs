using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 offset = new Vector3(0,5,0);

    void Start()
    {
        ;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 playerForward = player.transform.forward;
        playerForward = Vector3.Normalize(playerForward);

        transform.position = player.transform.position - playerForward*10 + offset;
        //Debug.Log(player);
        transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation( player.transform.position - transform.position ), Time.deltaTime*10 );

        
    }
}
