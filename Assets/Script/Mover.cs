using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float yValue = 0f;
    [SerializeField] float moveSpeed = 3f;
    float tmpMoveSpeed;
    bool isSpeedChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, yValue, -zValue);
    }

    void OnCollisionEnter(Collision other)
    {
        if (!isSpeedChanged)
        {
            tmpMoveSpeed = moveSpeed;
            moveSpeed = 3f;
            isSpeedChanged = true;
        }
        
    }

    void OnCollisionExit(Collision other)
    {
        moveSpeed = tmpMoveSpeed;
        isSpeedChanged = false;
    }
}
