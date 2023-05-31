using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Spawnner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2f;
    private float timer = 0f;
    public float heightOffset = 10f;
    private Bird_Script bird;


    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindWithTag("Player").GetComponent<Bird_Script>();
        
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else if (bird.birdIsAlive)
        {
            spawnPipe();
            timer = 0;
        }
    }
    
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
    }

}


