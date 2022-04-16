using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [SerializeField] string targetedPassword;
    [SerializeField] TextMeshProUGUI collectedPasswordTextMeshPro;
    [SerializeField] Color32 wrongPasswordColor;
    [SerializeField] Color32 truePasswordColor;

    private string _collectedPassword = "";
    
    // Start is called before the first frame update
    void Start()
    {
        collectedPasswordTextMeshPro.text = "";
        collectedPasswordTextMeshPro.color = truePasswordColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCharToPasswordString(string p)
    {
        _collectedPassword += p;
        collectedPasswordTextMeshPro.text = _collectedPassword;

        Debug.Log(_collectedPassword);

        CheckPasswords();
    }

    private void CheckPasswords()
    {
        if (targetedPassword.Equals(_collectedPassword))
        {
            Debug.Log("Oyun Bitti. yendin");
        }
        else if (!targetedPassword.StartsWith(_collectedPassword))
        {
            Debug.Log("Oyun Bitti");
            collectedPasswordTextMeshPro.color = wrongPasswordColor;
            Invoke("ReloadLevel", 1f);
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
