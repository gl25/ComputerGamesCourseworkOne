using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public enum Enemy
    {
        Chase,
        Attack
    }

    [SerializeField] private Enemy currState;

     Player character; // reference to player script
    GameObject PlayerObject;

    [SerializeField] private float attkDelay = 500.0f;
    private float nxtAttk = 500f;


    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        character = PlayerObject.GetComponent<Player>();

        if (character == null)
        {
            Debug.LogError("Player is Null");
        }
        if (PlayerObject == null)
        {
            Debug.LogError("Playerobject is Null");
        }

        currState = Enemy.Chase; 
    }

    public void movement()
    {
        agent.SetDestination(PlayerObject.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            currState = Enemy.Attack;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            currState = Enemy.Chase;
    }

    private void EnmyAttk()
    {
        switch (currState)
        {
            case Enemy.Chase:
                movement();
                break;

            case Enemy.Attack:
                nxtAttk += Time.deltaTime;
                if (attkDelay <= nxtAttk)
                {
                    character.Damage();
                    nxtAttk = 0f;
                }
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnmyAttk();
    }
}
