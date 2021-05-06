using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   [Tooltip("Start,InGame,Next,GameOver")]
   public List<GameObject> Panels;

   public List<GameObject> nextLevelPanels;
   public Image SniperFill;
   private bool isLevelCompleted = false;
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
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Panels[0].SetActive(true);

    }
   public void GameOver(){
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Panels[3].SetActive(true);
        Invoke("Restart",3);
   }
   public void LevelCompleted()
   {
       if (isLevelCompleted) return;
       if (SceneManager.GetActiveScene().buildIndex % 3 == 2)
       {
           
           nextLevelPanels[0].SetActive(true);
           
           SniperFill.fillAmount = .2f * SceneManager.GetActiveScene().buildIndex/3;
           

       }
       else
       {
           nextLevelPanels[(int)Random.Range(1f,2.9f)].SetActive(true);
           //her 3 bölümün 2sinde random bir sayı alıp int'e çeviriyor ve rastgele 2sinden birisi actif olmuş oluyor
       }
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Panels[2].SetActive(true);
        isLevelCompleted = true;


   }
   public void StartGame()
   {
        for (int i = 0; i < Panels.Count-1; i++)
        {
            Panels[i].SetActive(false);
            
        }
        Panels[1].SetActive(true);
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
