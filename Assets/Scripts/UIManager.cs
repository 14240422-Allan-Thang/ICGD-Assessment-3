using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTitle()
    {
        GameManager.CurrentGameState = GameManager.GameState.Title;
        SceneManager.LoadSceneAsync(0);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadLevel1()
    {
        GameManager.CurrentGameState = GameManager.GameState.Level1;
        SceneManager.LoadSceneAsync(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadLevel2()
    {
        GameManager.CurrentGameState = GameManager.GameState.Level2;
        SceneManager.LoadSceneAsync(2);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            exitButton = GameObject.FindGameObjectWithTag("ExitButton").GetComponent<Button>();
            exitButton.onClick.AddListener(LoadTitle);
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
