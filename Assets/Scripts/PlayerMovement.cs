using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    //public static PlayerMovement Instance;
    
    [SerializeField] float flySpeed = 7f;
    private Vector2 moveInput;
    private Rigidbody2D rb;   
    private Camera _camera;
    [SerializeField] private float XscreenBorder;
    [SerializeField] private float YscreenBorder;
    
    void OnMove (InputValue value)
    {
        moveInput = value.Get<Vector2>();
        
    }


    private void Awake()
    {

       _camera = Camera.main;
        //Instance = this;

    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();              
    }

    // Update is called once per frame
    void Update()
    {
        Flight();
    }

    public void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < XscreenBorder && rb.velocity.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - XscreenBorder && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if ((screenPosition.y < YscreenBorder && rb.velocity.y < 0) ||
            (screenPosition.y > _camera.pixelHeight - YscreenBorder && rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }


    private void Flight()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * flySpeed, moveInput.y * flySpeed);
        rb.velocity = playerVelocity;      
        PreventPlayerGoingOffScreen();
    }
}
