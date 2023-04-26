using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControl : MonoBehaviour
{
    public static bool IsMoveable = true;
    public Rigidbody2D WASDRb;
    public float moveSpeed = 1;
    public float moveTimes = 4;

    public Timer timerReference;  // Refer to the timer script in the scene

    
    void Start()
    {
        InitializeRigidbody2D();
        GetTimerReference(); 
    }
    

    void Update()
    {
        if(IsMoveable) { simpleWASDController(); }
        
    }
    
    
    // Initialize Rigidbody2D
    void InitializeRigidbody2D()
    {
        if (gameObject.GetComponent<Rigidbody2D>() == null) { gameObject.AddComponent<Rigidbody2D>(); }
        WASDRb = gameObject.GetComponent<Rigidbody2D>();
        WASDRb.gravityScale = 0;
        WASDRb.freezeRotation = enabled;
    }

    // if Player is in the big map, get the timer in the big map
    void GetTimerReference()
    {
        if (!GameManager.isPlayerAtShelter)
        {
            timerReference = GameObject.Find("TimerHolder").GetComponent<Timer>();
        }
    }

    void CountMove()
    {
        if (!GameManager.isPlayerAtShelter)
        {
            timerReference.CountStep();
        }
    }
    
    
    
    void transformGrid(float xMov,float yMov)
    {
        Vector3 target =
            new Vector3(transform.position.x + xMov, transform.position.y + yMov, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, moveSpeed);
    }
    void simpleWASDController()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            CountMove();
            transformGrid(0, GameManager.GM.gridScale);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CountMove();
            transformGrid(-GameManager.GM.gridScale, 0);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            CountMove();
            transformGrid(0, -GameManager.GM.gridScale);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            CountMove();
            transformGrid(GameManager.GM.gridScale, 0);
        }
        
    }
    
    
    

    /*void WASDController()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            IsMoveable = false; StartCoroutine(moveInGrid(0, GameManager.GM.gridScale));
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            IsMoveable = false; StartCoroutine(moveInGrid(-GameManager.GM.gridScale, 0));
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            IsMoveable = false; StartCoroutine(moveInGrid(0, -GameManager.GM.gridScale));
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            IsMoveable = false; StartCoroutine(moveInGrid(GameManager.GM.gridScale, 0));
        }
        
    }

    IEnumerator moveInGrid(float xMove, float yMove)
    {

        // set up reference, the current location and destination location
        /*Vector3 objectPosition = transform.position;
        Vector2 currentGrid = new Vector2(objectPosition.x, objectPosition.y);
        Vector2 direction = new Vector2(xMove, yMove);
        Vector2 destinationGrid = currentGrid + direction;#1#
        Vector2 destinationGrid = new Vector2(transform.position.x+xMove,transform.position.y + yMove);

        float currentMovement = 0;

        // set velocity to a certain value
        WASDRb.velocity = new Vector2(xMove, yMove) * moveSpeed;

        // track the distance of movement, as long as it reaches 1 unit of grid, stop
        while (currentMovement < GameManager.GM.gridScale)
        {
            yield return new WaitForSeconds(GameManager.GM.gridScale/(moveSpeed * moveTimes));
            currentMovement += GameManager.GM.gridScale/moveTimes;
            moveSpeed = (GameManager.GM.gridScale - currentMovement) / (GameManager.GM.gridScale * (moveTimes - 1) / (moveSpeed * moveTimes));
        }

        
        // set back
        WASDRb.velocity = Vector2.zero;
        transform.position = new Vector3(destinationGrid.x, destinationGrid.y);
        Debug.Log(IsMoveable);
        
        // unlock input
        IsMoveable = true;
        Debug.Log(IsMoveable);
        
        yield return null;
    }*/
    
    
    
    
    
}
