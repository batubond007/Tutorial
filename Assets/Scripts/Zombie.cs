using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform playerTransform;
    public NavMeshAgent agent;
    public Animation anim;
    public AnimationClip walkAnimation;
    public AnimationClip deathAnimation;

    private void Start()
    {
        playerTransform = Player.playerTransform;
    }

    private void Update()
    {
        agent.SetDestination(playerTransform.position);
    }

    public void Kill()
    {
        GameManager.instance.killCount++;
        anim.RemoveClip(walkAnimation);
        anim.AddClip(deathAnimation, "Death");
        anim.Play();
        Destroy(gameObject, 1);
    }
}
