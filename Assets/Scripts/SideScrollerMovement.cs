using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] float horDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Gets the horizontal move direction
        horDirection = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
        //Should player move right
        if (horDirection > 0.1)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

        //Should player move left
        if (horDirection < -0.1)
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
    }
}
