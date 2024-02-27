using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    private ThirdPersonCharacter m_character;
    private NavMeshAgent m_agent;
    
    void Awake()
    {
        m_character = GetComponent<ThirdPersonCharacter>();
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.SetDestination(transform.position);
    }

    private void Start()
    {
        m_agent.updateRotation = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                m_agent.SetDestination(hit.point);
            }
        }
        Camera.main.transform.parent.position = transform.position;

        if (m_agent.remainingDistance > m_agent.stoppingDistance)
        {
            m_character.Move(m_agent.desiredVelocity, false, false);
        } else { 
            m_character.Move(Vector3.zero, false, false);
        }
    }
}