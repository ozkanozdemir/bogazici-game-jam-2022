using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteScript : MonoBehaviour
{
    private bool _musicExist;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!_musicExist)
        {
            DontDestroyOnLoad(gameObject);
            _musicExist = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.StartsWith("Level") && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }       
    }
}
