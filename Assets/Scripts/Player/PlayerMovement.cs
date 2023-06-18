using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private Rigidbody2D MyRigidbody2D;
    private Animator anim;

    private Vector2 movement;

    private void Start()
    {
        MyRigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(movement.y == 0)
            movement.x = Input.GetAxisRaw("Horizontal");
        if(movement.x == 0)
            movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        MyRigidbody2D.MovePosition(MyRigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
