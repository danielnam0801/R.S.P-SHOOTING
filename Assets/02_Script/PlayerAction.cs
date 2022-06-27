using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed = 3f;
    float h;
    float v;
    bool isHorizonMove;

    Animator anim;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");
        
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if(hUp || vUp)
        {
            isHorizonMove = h != 0;
        }

        //Animation
        if (anim.GetInteger("hAxisRaw") != h) { 
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }
            
    }
    private void FixedUpdate()
    {
        //Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(v,);
        rigid.velocity = new Vector2(h,v).normalized * speed;
    }
}
