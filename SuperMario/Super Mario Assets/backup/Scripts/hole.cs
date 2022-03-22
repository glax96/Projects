using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other){

        if (other.tag == "Player"){

            Application.LoadLevel("Game Over");
        }
    }
}
