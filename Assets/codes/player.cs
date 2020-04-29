using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private Rigidbody2D rgPlayer;
    public LayerMask whatsGround;
    public Transform groundCheck;
    public bool grounded,jump;
    public BoxCollider2D stand, under;
    public float speed;
    private float h, v;
    public float jumpForce;
    private arma controleArma;
    private int idAnimation;
    private Animator animPlayer;


    // Start is called before the first frame update
    void Start()
    {
        rgPlayer = GetComponent<Rigidbody2D>();
        controleArma = FindObjectOfType(typeof(arma)) as arma;
        animPlayer = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (controleArma.estado!=StateGame.GAMEPLAY) return;
        rgPlayer.velocity =new Vector2(h*speed,rgPlayer.velocity.y);

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.002f, whatsGround);

    }

    // Update is called once per frame
    void Update()
    {
        if (controleArma.estado != StateGame.GAMEPLAY) return;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");


        if (v < 0)
        {
            idAnimation = 1;
            under.enabled=true;
            stand.enabled=false;
        }
        else
        {
            idAnimation = 0;

            under.enabled = false;
            stand.enabled = true;
        }

        if (grounded&&Input.GetButtonDown("Jump"))
        {
            
            rgPlayer.AddForce(new Vector3(rgPlayer.velocity.x, jumpForce,0));
            
        }
        if (!grounded) jump = true;
        else jump = false;
        if (jump&&v<0)
        {
            rgPlayer.AddForce(new Vector3(rgPlayer.velocity.x, -1*jumpForce, 0));
        }



        animPlayer.SetInteger("idAnimation",idAnimation);
        animPlayer.SetBool("grounded",grounded);
    }
}
