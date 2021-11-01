using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel1()
    {
        GameManager.CurrentGameState = GameManager.GameState.Level1;
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadLevel2()
    {
        GameManager.CurrentGameState = GameManager.GameState.Level2;
        SceneManager.LoadSceneAsync(2);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
