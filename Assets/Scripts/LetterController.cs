using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    [SerializeField] string letter = "A";

    private MainController _mainController;
    
    // Start is called before the first frame update
    void Start()
    {
        _mainController = FindObjectOfType<MainController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            _mainController.AddCharToPasswordString(letter);
            Destroy(gameObject);
        }
    }
}
