using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAI : MonoBehaviour
{

    Transform tr_Player;
    float f_RotSpeed = 3.0f, f_MoveSpeed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed*Time.deltaTime);

        //Move at Player
        transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
    }
}
