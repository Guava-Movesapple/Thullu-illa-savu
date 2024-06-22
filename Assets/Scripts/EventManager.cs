using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    private float timer = 0;
    public int score = 0;
    public Text scoreText;
    public GameObject deathScreen;
    public GameObject player;
    private bool isDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        deathScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
     if(!isDeath){
        scoreCount();
     }
    }
    private void scoreCount(){

        timer += Time.deltaTime;
       if(timer > 1)
       {
        score += 10;
        timer = 0;
       }
       scoreText.text = score.ToString();
    }

    public void death(){
        isDeath = true;
        GetComponent<AudioSource>().Stop();
        player.SetActive(false);
        deathScreen.SetActive(true);
        
    }

    public void restart(){
        Debug.Log("Restart");
        SceneManager.LoadScene("Game1");
    }

    public void menu(){
        SceneManager.LoadScene("MainMenu");
    }
}
