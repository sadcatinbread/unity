using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float multiplier;
    public float speed = 2;
    public float[] positions = new float[]{-1f,0f,1f};
    public int startingPos = 1;
    private int currentPos;

    void Start(){
        multiplier = 1;
        currentPos = startingPos;
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("left")){
            currentPos--;
        }
        if(Input.GetKeyDown("right")){
            currentPos++;
        }
        currentPos = Mathf.Clamp(currentPos, 0, 2);

        Vector3 targetPos = transform.position;
        targetPos.x = positions[currentPos];

        float step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards (transform.localPosition, targetPos, Time.deltaTime * speed);

    }
}
