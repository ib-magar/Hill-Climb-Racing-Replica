using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarSensor : MonoBehaviour
{
    public static event Action CoinsCollected;
    public GameManager _GameManager;
 
    private void Start()
    {
        _GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("coins"))
        {
            if(CoinsCollected!= null)
            CoinsCollected();
            //RequestEventTrigger(CoinsCollected);
            //_GameManager.destoyCoin(collision.gameObject);
            collision.GetComponent<Animator>().SetTrigger("goup");
        }
    }
   
}
