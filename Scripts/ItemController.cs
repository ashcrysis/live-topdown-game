using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControlelr : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private PlayerMovement playerScript;
    private Animator anim;

    public float itemIndex = 1;
    public int itemIndexAux = 0;
    private Vector2 pos = new Vector2(0,-1f);
    private void Start() {
        anim = GetComponent<Animator>();
        playerScript = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        itemIndexAux = (int)itemIndex;
        horizontal = playerScript.horizontal;
        vertical = playerScript.vertical;
          if (Input.GetKeyDown("q"))
        {
           itemIndex -=1;
           if (itemIndex == -1)
           {
            itemIndex = 2;
           }
        }
         if (Input.GetKeyDown("e"))
        {
            itemIndex +=1;
           if (itemIndex == 3)
           {
            itemIndex = 0;
           }
        }
        anim.SetFloat("horizontal",horizontal);
        anim.SetFloat("vertical",vertical);
        anim.SetFloat("ItemCode",itemIndex);
        if (horizontal != 0 || vertical != 0)
        {
            pos = new Vector2(horizontal,vertical);
        }

        else 
        {
            anim.SetFloat("horizontal",pos.x);
            anim.SetFloat("vertical",pos.y);
        }
    }
}
