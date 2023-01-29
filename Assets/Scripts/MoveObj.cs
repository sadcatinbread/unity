using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    public float force = 10;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force * GameObject.Find("PointCounter").GetComponent<PointCount>().diff, ForceMode.Impulse);
    }
}
