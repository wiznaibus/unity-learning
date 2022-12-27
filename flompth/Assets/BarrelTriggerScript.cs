using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTriggerScript : MonoBehaviour
{
    private LogicScript logicScript;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logicScript.addScore(1);
    }
}
