using Mono.Cecil.Cil;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public PlayerSettings playerSettings;

    private Rigidbody2D playerRigid;
    private CheckGrounded isGround;

    private void Awake()
    {
        playerRigid = player.GetComponent<Rigidbody2D>();
        isGround = player.GetComponent<CheckGrounded>();
    }
    
    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { moveInput = -1f; }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { moveInput = 1f; }
        
        playerRigid.linearVelocity = new Vector2(moveInput * playerSettings.WalkSpeed, playerRigid.linearVelocity.y);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGround.isGrounded) { playerRigid.AddForce(new Vector2(0f, playerSettings.JumpPower)); }
        }
    }

}
