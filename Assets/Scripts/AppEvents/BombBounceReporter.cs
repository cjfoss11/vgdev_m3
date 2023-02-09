using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBounceReporter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {

        if (c.impulse.magnitude > 0.25f)
        {
            EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.contacts[0].point);
        }
    }
}
