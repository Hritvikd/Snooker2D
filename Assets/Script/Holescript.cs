using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Holescript : MonoBehaviour
{
    public int score = 0;
    public Text ScoreText;
    int life = 3;
    public Rigidbody2D gb;
    Vector2 initpos;

    private Collider2D col;
    private void Start()
    {
        initpos = gb.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Normalball"))
        {
            AddScore();
            col = collision;
            
            Destroy(collision.gameObject);
            //Invoke("waitmethod", 5f);

        }
        if (collision.gameObject.CompareTag("Cueball"))
        {
            //Destroy(collision.gameObject);
            //Resetball();
            gb.position = initpos;
            gb.velocity = new Vector2(0, 0);
            life = life - 1;
        }
            
        
    }
    private void AddScore()
    {
       
            score = score + 5;
            ScoreText.text = score.ToString();
      
    }

    void Update()
    {
        if (life == 0)
        {
            //End Game
            SceneManager.LoadScene(3);
        }

        if (score >= 15)
        {
            //Won
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }
    
}
