using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemont : MonoBehaviour
{
    public float speed;

    public Animator animator;

    private Vector3 direction;

    //get input from player
    //apply movemont to sprite

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        direction = new Vector3(horizontal, Vertical);

        AnimateMovement(direction);
        //動畫部分
    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
