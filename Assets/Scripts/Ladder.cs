using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Mario")
        {
            Mario mario = col.gameObject.GetComponent<Mario>();
            mario.isTouchingLadder++;
            Debug.Log(mario.isTouchingLadder);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Mario")
        {
            Mario mario = col.gameObject.GetComponent<Mario>();
            mario.isTouchingLadder--;
            Debug.Log(mario.isTouchingLadder);
        }
    }
}
