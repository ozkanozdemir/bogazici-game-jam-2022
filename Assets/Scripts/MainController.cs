using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [SerializeField] string targetedPassword;

    private string _collectedPassword = "";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCharToPasswordString(string p)
    {
        _collectedPassword += p;
        
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
