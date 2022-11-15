using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacterMovement : MonoBehaviour
{

    [SerializeField]
    [Range(0,1000)] //This means that the MoveSpeed can be in range 0-1000
    private float MoveSpeed = 10.0f;

    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Hello World!");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 oldPosition = transform.position;

        Vector3 desiredVelocity = new Vector3(xInput, yInput, 0) * MoveSpeed;
        animator.SetFloat("Speed", desiredVelocity.sqrMagnitude);

        // Choose N S E or W based on movement direction

        CardinalDirection facing = CardinalDirection.SOUTH;
        if(desiredVelocity.x > 0)
        {
            facing = CardinalDirection.EAST;
        }
        else if (desiredVelocity.x < 0)
        {
            facing = CardinalDirection.WEST;
        }
        else if (desiredVelocity.y < 0)
        {
            facing = CardinalDirection.SOUTH;
        }
        else if (desiredVelocity.y > 0)
        {
            facing = CardinalDirection.NORTH;
        }

        animator.speed = MoveSpeed;
        animator.SetInteger("FacingDirection", (int)facing);

        transform.position = oldPosition + desiredVelocity * Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player Collided with " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered with " + collision.gameObject.name);
    }


    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.transform.tag == "Grass")
        {
            if (Random.Range(0, 101) <= 0.001)
            {
                Debug.Log("Encounter!");
                SwitchToCombatScene();
            }

        }
    }

    void SwitchToCombatScene()
    {
        SceneManager.LoadScene(2); //Index for the battle scene is 2
    }
}
