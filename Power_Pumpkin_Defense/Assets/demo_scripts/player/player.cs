using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : myTransform
{
    public GameObject model;
    public GameObject weapon;
    public camera cam;
    public Transform arm;

    public Animator animController;
    public PlayerInput playerInput;
    public Vector3 currentForward;

    public float camSpeed = 5;
    public float velocityFWD;
    public float velocityUP;

    public float accelerationH;
    public float deccelerationH;

    public float accelerationV;
    public float deccelerationV;

    public float velocityHLmit;
    public float walkingSpeedLimit = 8;
    public float runningSpeedLimit = 12;

    public float jumpHeight = 5;
    public float fallSpeed = -10;
    public float footSensor = 1;
    public float footResponce = 1;
    public float footResponceRate = 0.8f;

    public Vector2 leftStick;
    public Vector2 rightStick;
    public float pressure;

    public float targetAngle = 0;

    public i_PlayerState currentState;

    public Dictionary<playerStates,i_PlayerState> states;

    public Transform camFocusPoint;

    public float rotRate=0.5f;
    public void Start()
    {

        //cap frame rate at 60FPS
        Application.targetFrameRate = 55;


        cam = FindObjectOfType<camera>();

        //initialize input
        playerInput = new PlayerInput();
        playerInput.playerController.Enable();

        //I'll be using a lambda expression
        // I have to define a lambda expresstion by a context
        //defined lambda for reading left stick movement values
        playerInput.playerController.left_stick.performed += context => leftStick = context.ReadValue<Vector2>();
        playerInput.playerController.left_stick.canceled += context => leftStick = Vector2.zero;

        playerInput.playerController.right_stick.performed += context => rightStick = context.ReadValue<Vector2>();
        playerInput.playerController.right_stick.canceled += context => rightStick = Vector2.zero;

        playerInput.playerController.snapCamFWD.performed += context => setCamAngle();
        playerInput.playerController.jump.performed += context => jump();
        playerInput.playerController.sprint.performed += context => run();

        playerInput.playerController.attack.performed += context => attack();
        playerInput.playerController.attack.canceled += context => release();

        velocityFWD = 0;
        velocityUP = 0;

        //initialize states
        states = new Dictionary<playerStates, i_PlayerState>();
        states.Add(playerStates.idle, new idlePlayerState());
        states.Add(playerStates.walking, new walkPlayerState());
        states.Add(playerStates.running, new runPlayerState());
        states.Add(playerStates.midAir, new midAirPlayerState());
        states.Add(playerStates.activeAir, new activeAirPlayerState());

        currentState = states[playerStates.idle];
        currentState.onEnter(this);

        //initialize transform
        _position = transform.position;
        _rotation = transform.rotation;
        _scale = transform.localScale;
        computeTransform();
    }
    float velSideDelta;
    GameObject temp;

    public void attack()
    {
        temp = Instantiate(weapon,arm.position,arm.rotation);
        temp.GetComponent<pumpkinBlast>().arm = arm;
        temp.GetComponent<pumpkinBlast>().initialize();

        Debug.Log("pressed");
    }
    
    public void release()
    {
        Debug.Log("released");
        temp.GetComponent<pumpkinBlast>().shoot();
        temp.transform.forward = arm.forward;
    }

    //switch states and execute on enter and exit
    public void switchStates(playerStates state)
    {
        currentState.onExit(this);
        currentState = states[state];
        currentState.onEnter(this);
    }

    public RaycastHit hit = new RaycastHit();
    public Ray ray;
    
    public bool onGround = true;
    public float force = 5;

    Vector3 oldPosition;
    public Vector3 oldFWD;

    public void FixedUpdate()
    {
        
        velSideDelta =  transform.position.x - oldPosition.x;
        oldPosition = transform.position;

        if (rightStick.x != 0)
        {
            cam.targetAngleH += -rightStick.x * camSpeed * Time.deltaTime;

            

        }

        if (rightStick.y != 0)
        {
            cam.targetAngleV += -rightStick.y * camSpeed * Time.deltaTime;
            if (cam.targetAngleV > 2.6f)
            {
                cam.targetAngleV = 2.6f;
            }
            else if (cam.targetAngleV < 0.6f)
            {
                cam.targetAngleV = 0.6f;
            }
        }

        pressure = (Mathf.Abs(leftStick.x) + Mathf.Abs(leftStick.y));
        pressure = Mathf.Clamp(pressure,0,1);



        //shooting
        Ray ray = new Ray(cam.transform.position,cam.transform.forward);

        RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit,100, ~(1 << LayerMask.NameToLayer("Ignore Raycast"))))
        {
            //Debug.DrawRay(ray.origin, hit.point);

            arm.forward = hit.point - arm.position;

            //Debug.Log("Camera Collision");
        }




        

        //update curernt state
        currentState.update(this);

        raycastCollision();


        //cam.positionCamera(this);
        //compute current transform
        //computeTransform();
    }

    void jump()
    {
        if (currentState != states[playerStates.midAir])
        {
            Debug.Log("Jump");
            onGround = false;
            velocityUP = jumpHeight;
            switchStates(playerStates.midAir);
        }
    }

    void run()
    {
        switchStates(playerStates.running);
    }

    void setCamAngle()
    {
        //to solve the problem of interpolating across shortest possible angle between to angles
        //I just let the theta of the spherical coordinates loop over or under 360 by simply
        // adding the angle difference to the current theta and interpolating from there.
        // equation for shortest angle path
        Debug.Log("FROM: " + (cam.theta * Mathf.Rad2Deg) + " TO: " + targetAngle);
        cam.targetAngleH = ((cam.theta * Mathf.Rad2Deg) + (Mathf.DeltaAngle(cam.theta * Mathf.Rad2Deg, targetAngle))) * Mathf.Deg2Rad;

        Debug.Log("shortest angle between: " + (Mathf.DeltaAngle(cam.theta * Mathf.Rad2Deg, targetAngle)));
    }

    void enable()
    {
        playerInput.playerController.Enable();
    }

    void disable()
    {
        playerInput.playerController.Disable();
    }

   
    void raycastCollision()
    {
        float rH = -0.5f;
        //collision resolution
        ray = new Ray(transform.position + new Vector3(0, 1, 0) * rH, transform.forward);

        float legnts = 0.8f;
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0) * rH, transform.forward, Color.cyan, legnts);
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0) * rH, transform.right, Color.cyan, legnts);
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0) * rH, -transform.right, Color.cyan, legnts);
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0) * rH, -transform.right + transform.forward, Color.cyan, legnts);
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0) * rH, transform.right + transform.forward, Color.cyan, legnts);
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0) * rH, -transform.right - transform.forward, Color.cyan, legnts);
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0) * rH, transform.right - transform.forward, Color.cyan, legnts);

        //collision with walls
        if (Physics.Raycast(ray, out hit, legnts))
        {
            Vector3 forceDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.position -= forceDir * force * Time.deltaTime;
            //Debug.Log("Camera Collision");
        }
        ray = new Ray(transform.position + new Vector3(0, 1, 0) * rH, transform.right);

        //collision with walls
        if (Physics.Raycast(ray, out hit, legnts))
        {
            Vector3 forceDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.position -= forceDir * force * Time.deltaTime;
            //Debug.Log("Camera Collision");
        }
        ray = new Ray(transform.position + new Vector3(0, 1, 0) * rH, -transform.right);

        //collision with walls
        if (Physics.Raycast(ray, out hit, legnts))
        {
            Vector3 forceDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.position -= forceDir * force * Time.deltaTime;
            //Debug.Log("Camera Collision");
        }

        ray = new Ray(transform.position + new Vector3(0, 1, 0) * rH, transform.right + transform.forward);

        //collision with walls
        if (Physics.Raycast(ray, out hit, legnts))
        {
            Vector3 forceDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.position -= forceDir * force * Time.deltaTime;
            //Debug.Log("Camera Collision");
        }
        ray = new Ray(transform.position + new Vector3(0, 1, 0) * rH, -transform.right + transform.forward);

        //collision with walls
        if (Physics.Raycast(ray, out hit, legnts))
        {
            Vector3 forceDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.position -= forceDir * force * Time.deltaTime;
            //Debug.Log("Camera Collision");
        }
    }

    void falling()
    {
        ray = new Ray(transform.position, -transform.up);
        Debug.DrawRay(transform.position, -transform.up, Color.blue);


        velocityUP -= deccelerationV * Time.deltaTime;
        if (velocityUP <= fallSpeed)
        {
            velocityUP = fallSpeed;
        }


        ray = new Ray(transform.position, -transform.up);



        if (Physics.Raycast(ray, out hit, 1.5f))
        {
            Debug.DrawLine(ray.origin, hit.point);
            //Debug.Log(hit.collider.name);

            if (hit.collider.tag == "ground" && velocityUP < 0)
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + 1, transform.position.z);
                velocityUP = 0;
                onGround = true;

                if (leftStick != Vector2.zero)
                    switchStates(playerStates.running);
                else if (leftStick == Vector2.zero)
                    switchStates(playerStates.idle);
            }
        }

        Vector3 directionUp = new Vector3(0, 1, 0) * velocityUP * Time.deltaTime;

        //move vertically
        transform.Translate(directionUp, Space.World);
    }

}
