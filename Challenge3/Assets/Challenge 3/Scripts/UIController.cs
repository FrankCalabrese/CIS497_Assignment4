/*Frank Calabrese   
 * Challenge 3
 * keeps and displays score and win/loss
 * allows restart after game over
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public int score = 0;
    public Text textbox;

    public int winningScore = 5;

    public PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();

        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver) textbox.text = "Score: " + score;

        if(score < winningScore && playerControllerScript.gameOver == true)
        {
            textbox.text = "you lose! press R to try again";
        }

        if (score >= winningScore)
        {
            playerControllerScript.gameOver = true;

            textbox.text = "you won! press R to play again";
        }

        if(playerControllerScript.gameOver == true && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
