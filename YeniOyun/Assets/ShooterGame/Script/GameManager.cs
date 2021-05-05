using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   [Tooltip("Start,ÝnGame,Next,GameOver")]
   public List<GameObject> Panels;
   public Text AmmoText;
   Player player;
   void Start()
   {
        player = FindObjectOfType<Player>();
        WhenStart();
    }

   void Update()
   {
        if (player != null)
        {
            AmmoText.text = player.ammo.ToString();
            if (player.ammo == 0 && GameObject.FindGameObjectWithTag("Enemy") != null && !player.fire)
                GameOver();
        }
        if (GameObject.FindGameObjectWithTag("Enemy") == null) {
            player.Win();
            LevelCompleted();
        }
    }
    void WhenStart()
    {
        for (int i = 0; i < Panels.Count-1; i++)
        {
            Panels[i+1].SetActive(false);
        }
    }
   public void GameOver(){
        for (int i = 0; i < Panels.Count-1; i++)
        {
            Panels[i].SetActive(false);
            Panels[3].SetActive(true);
        }
        Invoke("Restart",3);
   }
   public void LevelCompleted()
   {
        for (int i = 0; i < Panels.Count-1; i++)
        {
            Panels[i].SetActive(false);
            Panels[2].SetActive(true);
        }
   }
   public void StartGame()
   {
        for (int i = 0; i < Panels.Count-1; i++)
        {
            Panels[i].SetActive(false);
            Panels[1].SetActive(true);
        }
    }
   public void Restart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   public void NextLevel()
   {

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   public void CloseAd(){}
}
