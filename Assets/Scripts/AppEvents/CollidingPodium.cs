using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingPodium : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            PodiumInteractor pi = c.attachedRigidbody.gameObject.GetComponent<PodiumInteractor>();
            if (pi != null)
            {
                pi.KnockOver();
                EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);
                anim.Play("dice");
            }
        }

    }

    void OnTriggerExit(Collider c)
    {
        anim.Play("default");
    }
}
