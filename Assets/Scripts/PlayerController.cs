using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpAmount = 10f;
    [SerializeField] Animator animator;
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private AudioClip dieClip;
    [SerializeField] private AudioClip collactedClip;
    
    private Rigidbody2D _rigidbody;
    
    private Vector3 _velocity;
    private bool _isDead;
    private MainController _mainController;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // _rigidbody değişkenine objenin RigidBody2d komponentini ata
        _rigidbody = GetComponent<Rigidbody2D>();
        
        // _mainController değişkenine MainController sınıfını ata
        _mainController = FindObjectOfType<MainController>();
        
        // Audip source
        _audioSource = GetComponent<AudioSource>();
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
            animator.SetFloat("Speed", Mathf.Abs(horizontalAxisRaw));

            // Zıplama hareketi
            if (Input.GetButtonDown("Jump") && Mathf.Approximately(_rigidbody.velocity.y, 0))
            {
                _rigidbody.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
                animator.SetBool("IsJumping", true);
            }

            if (!Mathf.Approximately(_rigidbody.velocity.y, 0))
            {
                animator.SetBool("IsJumping", true);
            }

            if (animator.GetBool("IsJumping") && Mathf.Approximately(_rigidbody.velocity.y, 0))
            {
                animator.SetBool("IsJumping", false);
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
        else
        {
            // Ölme sesi
            AudioSource.PlayClipAtPoint(dieClip, transform.position);
            
            // Koşma animasyonunu bitir
            animator.SetFloat("Speed", 0);
            
            // Ölme effekti
            GameObject dieEffectGameObject = Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(dieEffectGameObject, 1.5f);
            Destroy(gameObject);

            // Oyun başarısız şekilde bitti
            _mainController.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Oyuncunun dokunduğu objenin tag'i floor veya Killer ise oyuncuyu öldür ve bölümü yeniden başlat
        if (col.gameObject.tag.Equals("Floor") || col.gameObject.tag.Equals("Killer"))
        {
            // oyuncuyu öldür
            _isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Letter"))
        {
            // Toplama sesi
            AudioSource.PlayClipAtPoint(collactedClip, transform.position);
        }
    }

    // Player'ın ölme durumunun tutulduğu değişkeni güncelleme
    public void SetIsDead(bool value)
    {
        _isDead = value;
    }
}
