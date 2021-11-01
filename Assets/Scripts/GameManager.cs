using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Title, Level1, Level2 };
    private static GameState currentGameState = GameState.Title;
    public static GameState CurrentGameState { get; set; }
    // Start is called before the first frame updae
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
