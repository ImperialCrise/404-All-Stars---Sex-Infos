using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public Animator AnimatorCharacter;

    public GameObject MovePan;
    
    public Vector2 movementDirection;
    public float movementSpeed;

    public GameObject actuel;
    public bool clicked = false;
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        transform.eulerAngles = Vector3.zero;
    }

    public Vector3 lastpos = Vector3.zero;

    void Update()
    {
        CheckMousePos();
        ProcessMovement();
        clicked = false;
    }

    private void CheckMousePos()
    {
        if (MenuSystem.Instance.isDefinedOpen || !IntroductionSystem.Instance.isFinished)
        {
            agent.ResetPath();
            return;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            lastpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastpos.z = 0;
            Debug.Log($"New pos: {lastpos}");
            clicked = true;

            if (actuel)
                Destroy(actuel);
            
            actuel = Instantiate(MovePan, lastpos, Quaternion.identity);
        }
    }
    
    private void ProcessMovement()
    {
        agent.SetDestination(lastpos);
        movementDirection = agent.velocity;
        
        movementDirection = agent.velocity;
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
        
        AnimatorCharacter.SetFloat("Horizontal", movementDirection.x);
        AnimatorCharacter.SetFloat("Vertical", movementDirection.y);
        AnimatorCharacter.SetBool("Idle", movementSpeed < 0.1 && movementDirection.y < 0.1 && movementDirection.x < 0.1);
    }


 
}
