using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody rb;
    public bool isWalking;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isWalking = false;
    }

    private void Update()
    {
        // move the player
        ControlPlayer();
        //animator = GetComponent<Animator>();
    }

    private void ControlPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F));
        }
        rb.MovePosition(transform.position + (movement * moveSpeed * Time.deltaTime));


        if(moveHorizontal != 0 || moveVertical != 0)
        {
            isWalking = true;
        } else
        {
            isWalking = false;
        }
    }

}