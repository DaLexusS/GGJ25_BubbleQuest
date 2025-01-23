using Mono.Cecil.Cil;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public PlayerSettings playerSettings;

    private Rigidbody2D playerRigid;
    private bool isGrounded = false;
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

        if (Input.GetKey(KeyCode.A)) { moveInput = -1f; }
        else if(Input.GetKey(KeyCode.D)) { moveInput = 1f; }
        
        playerRigid.linearVelocity = new Vector2(moveInput * playerSettings.WalkSpeed, playerRigid.linearVelocity.y);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround.isGrounded)
        {
            playerRigid.AddForce(new Vector2(0f, playerSettings.JumpPower));
        }
    }

}
