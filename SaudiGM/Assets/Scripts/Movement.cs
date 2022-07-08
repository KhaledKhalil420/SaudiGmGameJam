using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform GroundCheck, Head;
    [SerializeField] Transform MainCa;

    public float Speed, SprintingSpeed, GroundDrag, CurrentSpeed, CounterMovementDrag;
    
    [SerializeField] float JumpForce, JumpRadius, AirDrag;
    [SerializeField] LayerMask GroundLayer;

    [SerializeField] float CrouchingForce, CrouchingDrag, CrouchingSpeed, HeadSize;

    [HideInInspector]
    public Rigidbody Rb;
    Vector3 MoveDir;
    float SideWays, Forward;
    bool IsWallAbove, IsCrouching, DoCrouchForce, IsGrounded, IsMoving;
    public bool HasJumpAbility, CanRun;
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        CurrentSpeed = Speed;
        MainCa = GameObject.FindGameObjectWithTag("MainCamera").transform;
        CanRun = true;
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
        if(Input.GetButtonUp("Horizontal") && IsGrounded || Input.GetButtonUp("Vertical") && IsGrounded)
        Rb.drag = CounterMovementDrag;
    }

    void Inputs()
    {
       SideWays = Input.GetAxisRaw("Horizontal");
       Forward = Input.GetAxisRaw("Vertical");
       MoveDir = transform.right * SideWays + transform.forward * Forward;

       if(SideWays != 0 || Forward != 0)
       IsMoving = true;
       else
       IsMoving = false;

       if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
       {
            Jump(JumpForce);
       }

       if(Input.GetKeyDown(KeyCode.Space) && HasJumpAbility && IsMoving)
       {
            Jump(JumpForce);
            HasJumpAbility = false;
       }

       if(Input.GetKey(KeyCode.LeftShift) && !IsCrouching && CanRun)
        CurrentSpeed = SprintingSpeed;
       if(Input.GetKeyUp(KeyCode.LeftShift))
        CurrentSpeed = Speed;

       if(Input.GetKey(KeyCode.C))
       StartCrouching();
       if(!Input.GetKey(KeyCode.C) && !IsWallAbove)
       StopCrouching();
       if(Input.GetKeyUp(KeyCode.C) && !IsWallAbove)
       StopCrouching();
       if(Input.GetKeyDown(KeyCode.C) && !IsWallAbove && IsGrounded)
       {
        StartCrouching();
        Rb.AddForce(transform.forward * CrouchingForce, ForceMode.Force);
       }
       if(Input.GetKeyDown(KeyCode.C) && !IsWallAbove && !IsGrounded)
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