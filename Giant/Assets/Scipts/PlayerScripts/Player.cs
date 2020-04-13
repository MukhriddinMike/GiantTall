using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 8f, maxVelocity = 4f;

    [SerializeField]
    private Rigidbody2D myRigid;
    private Animator anim;

    void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myRigid.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0 )
        {
            if (vel < maxVelocity)
                forceX = speed;

            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
                forceX = -speed;

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        myRigid.AddForce(new Vector2(forceX, 0));
    }
}
