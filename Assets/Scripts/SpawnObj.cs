using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public float baseInterval = 5;
    public float modifier;

    public GameObject[] prefabs;

    public float[] positions = new float[]{-3f,0f,3f};
    public int startingPos = 1;

    public float interval;
    private int currentPos;

    public int maxTries = 100;

    private int randomNumber;
    private int tries;
    private int lastNumber;

    private int lastNumberPos;
    private int randomNumberPos;
    private int triesPos;

    float timer; 

    void NewRandomNumberWall(){
        while(lastNumber == randomNumber && tries != maxTries ){
            randomNumber = (int)Mathf.Clamp(Random.Range(0f, 3f),0,2);
            tries++;
        }
        if(tries == maxTries){
            Debug.LogError("Reached Max Tries while Generating Numbers!");
        }
        lastNumber = randomNumber;
        tries = 0;
    }

    void NewRandomNumberPos(){
        while(lastNumberPos == randomNumberPos && triesPos != maxTries ){
            randomNumberPos = (int)Mathf.Clamp(Random.Range(0f, 3f),0,2);
            triesPos++;
        }
        if(triesPos == maxTries){
            Debug.LogError("Reached Max Tries while Generating Numbers!");
        }
        lastNumberPos = randomNumberPos;
        triesPos = 0;
    }

    void Start(){
        modifier = 1;
        currentPos = startingPos;
        tries = 0;
        triesPos = 0;
        Random.InitState(System.DateTime.Now.Millisecond);
    }
    

    void FixedUpdate(){
        timer += Time.deltaTime;
        interval = baseInterval / modifier;
        if(timer >= baseInterval / modifier){
            NewRandomNumberWall();
            GameObject wall = prefabs[randomNumber];

            NewRandomNumberPos();
            Vector3 targetPos = transform.position;
            targetPos.x += positions[randomNumberPos];

            Instantiate(wall, targetPos, Quaternion.Euler(180,0,0), transform);
            timer -= baseInterval;
        }
    }
}
