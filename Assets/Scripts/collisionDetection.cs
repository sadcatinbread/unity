using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            GameObject.Find("EventSystem").GetComponent<MenuController>().failed = true;
        }
    }
}
