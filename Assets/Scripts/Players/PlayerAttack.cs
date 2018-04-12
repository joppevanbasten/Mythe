﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    private float thrust = 5;
    private float distance;
    [SerializeField]
    private GameObject trigger;
    private bool isLeft;

    private bool isTriggered = false;
    private GameObject enemy;

    public void Attack(KeyCode Key)
    {
        distance = Mathf.Abs(gameObject.transform.position.x - enemy.transform.position.x);
        thrust = Mathf.Abs(2f-distance)*4;
        //Debug.Log("Distance: " + distance);
        //Debug.Log("Thrust: " + thrust);
        if (Input.GetKeyDown(Key) && isTriggered)
        {
            if (isLeft)
            {
                enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * thrust, ForceMode2D.Impulse);
            }
            else
            {
                enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * thrust, ForceMode2D.Impulse);
            }
        }
    }

    public void ChangeHitbox(string side)
    {
        if (side == "left")
        {
            trigger.transform.position = trigger.transform.parent.position - new Vector3(GetComponent<BoxCollider2D>().size.x / 10 + 0.11f, 0, 0);
            isLeft = true;
        }
        else
        {
            trigger.transform.position = trigger.transform.parent.position + new Vector3(GetComponent<BoxCollider2D>().size.x / 10 + 0.11f, 0, 0);
            isLeft = false;
        }
    }


    void OnTriggerStay2D(Collider2D col)
    {
           if (col.gameObject.tag == "Player")
           {
                isTriggered = true;
                enemy = col.gameObject;
                Debug.Log(enemy);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggered = false;
        }
    }
}
