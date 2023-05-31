using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Script : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public Logic_Script logic;
    public bool birdIsAlive = true;
    public float viewLimit = 13.0f;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<Logic_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y + viewLimit < Camera.main.transform.position.y || transform.position.y - viewLimit > Camera.main.transform.position.y)
        {
            // If outside camera view, end the game
            endGame();
        }
    }

    private void endGame()
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        endGame();
    }


}
