using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public float baseInterval = 5;
    public float modifier = 1;

    public GameObject[] prefabs;

    public float[] positions = new float[]{-3f,0f,3f};
    public int startingPos = 1;
    private int currentPos;

    private int randomNumber;
    private int lastNumber;
    public int maxAttempts = 10;

    public Transform spawnpoint;

    float timer;

    void NewRandomNumber(){
        for(int i=0; randomNumber == lastNumber && i < maxAttempts; i++){
            randomNumber = Random.Range(0, 2);
        }
        lastNumber = randomNumber;
    }

    void Start(){
        modifier = 1;
        currentPos = startingPos;
    }
    

    void Update(){
        timer += Time.deltaTime;
        if(timer >= baseInterval * modifier){
            NewRandomNumber();
            GameObject wall = prefabs[randomNumber];

            NewRandomNumber();
            Vector3 targetPos = transform.position;
            targetPos.x += positions[randomNumber];

            Instantiate(wall, targetPos, Quaternion.Euler(180,0,0), transform);
            timer -= baseInterval;
        }
    }
}
