using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecreaseTrigger : MonoBehaviour
{
    [SerializeField]
    private int healthDecreaseAmount = 10;

    [SerializeField]
    private HealthManager healthManager;

    private void OnTriggerEnter(Collider other)
    {
        healthManager.DecreaseHealth(healthDecreaseAmount);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
