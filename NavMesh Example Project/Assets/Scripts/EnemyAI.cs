/*
 * Zechariah Burrus
 * Assignment 9
 * EnemyAI causes an enemy to chase the player within a specified distance
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class EnemyAI : MonoBehaviour {
    public Camera cam;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    public GameObject player;

    public float chaseDistance;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        player = GameObject.FindGameObjectWithTag("Player");
        //Third person character is controlling rotation for us so we don't
        //want the agent to update it as well
        agent.updateRotation = false;
        chaseDistance = 8.0f;
    }

    // Update is called once per frame
    void Update() {
        MoveEnemy();
    }

    private void MoveEnemy() {
        float distanceFromTarget = Vector3.Distance(transform.position, player.transform.position);

        if (distanceFromTarget > agent.stoppingDistance && distanceFromTarget < chaseDistance) {
            agent.SetDestination(player.transform.position);
            character.Move(agent.desiredVelocity, false, false);
        } else {
            agent.SetDestination(transform.position);
            character.Move(Vector3.zero, false, false);
        }
    }
}