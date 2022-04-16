using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpAmount = 10f;

    private Rigidbody2D _rigidbody;

    private Vector3 _velocity;
    private bool _isDead = false;
    private MainController _mainController;

    // Start is called before the first frame update
    void Start()
    {
        // _rigidbody değişkenine objenin RigidBody2d komponentini ata
        _rigidbody = GetComponent<Rigidbody2D>();
        
        // _mainController değişkenine MainController sınıfını ata
        _mainController = FindObjectOfType<MainController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Yatay hareket miktarı
        float horizontalAxisRaw = Input.GetAxisRaw("Horizontal");
        
        // Ölmediyse hareket edebilir
        if (!_isDead)
        {
            // yatay hareket
            _velocity = new Vector3(horizontalAxisRaw, 0f);
            transform.position += _velocity * moveSpeed * Time.deltaTime;

            // Zıplama hareketi
            if (Input.GetButtonDown("Jump") && Mathf.Approximately(_rigidbody.velocity.y, 0))
            {
                _rigidbody.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            }
            
            // Oyuncu ssola dönük ise 180 derece y ekseninde rotate ediliyor
            // Sağa dönük ise y ekseninin rotate değeri 0 yapılıyor
            if (horizontalAxisRaw <= -0.5f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (horizontalAxisRaw >= 0.5f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);   
            }   
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Oyuncunun dokunduğu objenin tag'i floor ise oyuncuyu öldür ve bölümü yeniden başlat
        if (col.gameObject.tag.Equals("Floor"))
        {
            // oyuncuyu öldür
            _isDead = true;
            
            // Oyun başarısız şekilde bitti
            _mainController.GameOver();
        }
    }

    // Player'ın ölme durumunun tutulduğu değişkeni güncelleme
    public void SetIsDead(bool value)
    {
        _isDead = value;
    }
}
