using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float flapStrength = 9;
    public float spinStrength = 15;
    private LogicScript logicScript;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logicScript.gameEnded)
        {
            rigidbody2d.simulated = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2d.velocity = Vector2.up * flapStrength;
                rigidbody2d.angularVelocity -= spinStrength;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.gameOver();
    }
}
