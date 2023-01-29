using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCount : MonoBehaviour
{
    public float diff = 1f;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Wall"){
            GameObject.Find("EventSystem").GetComponent<MenuController>().score += 1;
            diff += 0.1f;
            GameObject.Find("Moveable").GetComponent<SpawnObj>().modifier += 0.1f;
        }
    }
}
