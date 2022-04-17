using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteScript : MonoBehaviour
{
    private static bool _musicExist;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!_musicExist)
        {
            _musicExist = true;
            Debug.Log("Not Destroyed");
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().name.StartsWith("Level") || 
             SceneManager.GetActiveScene().name.StartsWith("level")) && 
            Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }       
    }
}
