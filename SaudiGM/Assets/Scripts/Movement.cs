using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform GroundCheck, Head;
    Transform MainCa;

    public float Speed, SprintingSpeed, GroundDrag, CurrentSpeed, CounterMovementDrag;

    public float JumpForce, JumpRadius, AirDrag;
    public LayerMask GroundLayer;

    public float CrouchingForce, CrouchingDrag, CrouchingSpeed, HeadSize;

    [HideInInspector]
    public Rigidbody Rb;
    Vector3 MoveDir;
    float SideWays, Forward;
    bool IsGrounded, IsWallAbove, IsCrouching, DoCrouchForce, IsRuning;
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        CurrentSpeed = Speed;
        MainCa = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
       Inputs();
       ControlDrag();
       RayCasts();
       CounterMovement();
    }

    void CounterMovement()
    {
        if(Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        Rb.drag = CounterMovementDrag;
    }

    void Inputs()
    {
       SideWays = Input.GetAxisRaw("Horizontal");
       Forward = Input.GetAxisRaw("Vertical");
       MoveDir = transform.right * SideWays + transform.forward * Forward;

       if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
       {
            Jump(JumpForce);
       }

       if(Input.GetKey(KeyCode.LeftShift) && !IsCrouching)
        CurrentSpeed = SprintingSpeed;
       if(Input.GetKeyUp(KeyCode.LeftShift))
        CurrentSpeed = Speed;

       if(Input.GetKey(KeyCode.LeftControl))
       StartCrouching();
       if(!Input.GetKey(KeyCode.LeftControl) && !IsWallAbove)
       StopCrouching();
       if(Input.GetKeyUp(KeyCode.LeftControl) && !IsWallAbove)
       StopCrouching();
       if(Input.GetKeyDown(KeyCode.LeftControl) && !IsWallAbove && IsGrounded)
       {
        StartCrouching();
        Rb.AddForce(transform.forward * CrouchingForce, ForceMode.Force);
       }
       if(Input.GetKeyDown(KeyCode.LeftControl) && !IsWallAbove && !IsGrounded)
       {
        StartCrouching();
        DoCrouchForce = true;
       }
       if(DoCrouchForce && IsGrounded)
       {
        DoCrouchForce = false;
        Rb.AddForce(transform.forward * CrouchingForce, ForceMode.Force);
       }
    }

    void RayCasts()
    {
       IsGrounded = Physics.CheckSphere(GroundCheck.position, JumpRadius, GroundLayer);
       IsWallAbove = Physics.CheckSphere(Head.position, HeadSize, GroundLayer);
    }

    void StartCrouching()
    {
        MainCa.eulerAngles = new(MainCa.eulerAngles.x, MainCa.eulerAngles.y, 10);
        transform.localScale = new Vector3(1, 0.4f ,1);
        Rb.drag = CrouchingDrag;
        IsCrouching = true;
    }

    void StopCrouching()
    {
        MainCa.eulerAngles = new(MainCa.eulerAngles.x, MainCa.eulerAngles.y, 0);
        DoCrouchForce = false;
        transform.localScale = new Vector3(1, 1.5f ,1);
        IsCrouching = false;
    }

    void ControlDrag()
    {
        if(IsGrounded)
        Rb.drag = GroundDrag;
        else
        Rb.drag = AirDrag;
    }

    public void Jump(float _JumpForce)
    {
        Rb.AddForce(Vector3.up * _JumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Rb.AddForce(MoveDir * CurrentSpeed, ForceMode.Acceleration);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(GroundCheck.position, JumpRadius);
        Gizmos.DrawWireSphere(Head.position, HeadSize);
    }
}