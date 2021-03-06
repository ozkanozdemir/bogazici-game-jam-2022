using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField] string targetedPassword;
    [SerializeField] Text collectedPasswordText;
    [SerializeField] Text gameOverText;
    [SerializeField] Color32 wrongPasswordColor;
    [SerializeField] Color32 truePasswordColor;
    [SerializeField] GameObject finishObject;

    private string _collectedPassword = "";
    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        // collectedPasswordText text'ini sıfırla
        collectedPasswordText.text = "";

        // _playerController değişkenine PlayerController sınıfını ata
        _playerController = FindObjectOfType<PlayerController>();
        
        // gameOverText text'ini sıfırla
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCharToPasswordString(string p)
    {
        // Eklenen karakteri _collectedPassword değişkenine ekle
        _collectedPassword += p;
        
        // collectedPasswordTextMeshPro text değerini güncelle
        collectedPasswordText.text = _collectedPassword;
        
        // Parolanın son halini kontrol et
        CheckPasswords();
    }

    // Parolanın son halini kontrol etme
    private void CheckPasswords()
    {
        // Parolanın son hali olması gereken ile aynı ise sonraki bölümü yükle
        if (targetedPassword.Equals(_collectedPassword))
        {
            // collectedPasswordTextMeshPro rengini değiştir
            collectedPasswordText.color = truePasswordColor;
            
            // Finish objecti görünür yap
            finishObject.SetActive(true);
            
            // Sonraki bölümü yükle
            // Invoke("NextLevel", 1f);
        }
        else if (!targetedPassword.StartsWith(_collectedPassword))
        {            
            // Oyuncuyu öldür
            _playerController.SetIsDead(true);
            
            // collectedPasswordTextMeshPro rengini değiştir
            collectedPasswordText.color = wrongPasswordColor;
            
            // Oyun başarısız şekilde bitti
            GameOver();
        }
    }

    // Bölümü yeniden yükleme
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        Invoke("NextLevel", 1f);
    }
    
    // Sonraki bölümü yükleme
    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Oyun bittiğinde (başarısız şekilde) yapılacak işlemler
    public void GameOver()
    {
        // gameOverText text'ini güncelle
        gameOverText.text = "GAME OVER";
        
        // 1 saniye sonra, aynı sahneyi yeniden yükle
        Invoke("ReloadLevel", 1.5f);
    }
}
