using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Script : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float deadZone = -45f;
    private Bird_Script birdObject;
    // Start is called before the first frame update
    void Start()
    {
        birdObject = GameObject.FindWithTag("Player").GetComponent<Bird_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdObject.birdIsAlive == true)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
