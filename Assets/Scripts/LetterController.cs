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
        // _mainController değişkenine MainController sınıfını ata
        _mainController = FindObjectOfType<MainController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Letter objesine dokunan Player objesi ise _mainController'ı kullanarak toplananan password text'ini toplanan 
        // karakteri ekle ve bu objeyi yok et
        if (col.tag.Equals("Player"))
        {
            // TODO: Toplandı sesini çal
            
            // Toplanan password text'ine bu karakteri ekle
            _mainController.AddCharToPasswordString(letter);
            
            // Objeyi yok et
            Destroy(gameObject);
        }
    }
}
