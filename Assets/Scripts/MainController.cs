using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [SerializeField] string targetedPassword;
    [SerializeField] TextMeshProUGUI collectedPasswordText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Color32 wrongPasswordColor;
    [SerializeField] Color32 truePasswordColor;

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

        Debug.Log(_collectedPassword);

        // Parolanın son halini kontrol et
        CheckPasswords();
    }

    // Parolanın son halini kontrol etme
    private void CheckPasswords()
    {
        // Parolanın son hali olması gereken ile aynı ise sonraki bölümü yükle
        if (targetedPassword.Equals(_collectedPassword))
        {
            Debug.Log("Oyun Bitti. yendin");
            
            // collectedPasswordTextMeshPro rengini değiştir
            collectedPasswordText.color = truePasswordColor;
            
            // Sonraki bölümü yükle
            Invoke("NextLevel", 1f);
        }
        else if (!targetedPassword.StartsWith(_collectedPassword))
        {
            Debug.Log("Oyun Bitti");
            
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
        Invoke("ReloadLevel", 1f);
    }
}
