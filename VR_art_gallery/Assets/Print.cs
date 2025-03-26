using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class print : MonoBehaviour

{
    public GameObject textO;
    // Start is called before the first frame update
    void Start()
    {
            textO.SetActive(false);
            Debug.Log("hi" );



    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
{
    Debug.Log("Triggered by: " );
    textO.SetActive(true);
}

void OnTriggerExit(Collider other){

    textO.SetActive(false);
}

}