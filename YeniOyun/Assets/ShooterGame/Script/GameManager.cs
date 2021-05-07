using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   [Tooltip("Start,InGame,Next,GameOver")]
   public List<GameObject> panels;

   public List<GameObject> nextLevelPanels;
   public Image sniperFill;
   private bool isLevelCompleted;
   private Player player;
   private void Start()
   {
        player = FindObjectOfType<Player>();
        WhenStart();
    }
   private void Update()
   {
        if (player != null)
        {
            
            if (player.ammo == 0 && GameObject.FindGameObjectWithTag("Enemy") != null && !player.fire)
                GameOver();
        }
        if (GameObject.FindGameObjectWithTag("Enemy") == null) 
        { 
            player.Win(); 
            LevelCompleted();
        }
   }
   private void WhenStart()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        panels[0].SetActive(true);

    }
   public void GameOver(){
       foreach (GameObject panel in panels)
       {
           panel.SetActive(false);
       }
       panels[3].SetActive(true);
       Invoke(nameof(Restart),3);
   }
   private void LevelCompleted()
   {
       if (isLevelCompleted) return;
       if (SceneManager.GetActiveScene().buildIndex % 3 == 2)
       {
           
           nextLevelPanels[0].SetActive(true);
           
           sniperFill.fillAmount = .2f * SceneManager.GetActiveScene().buildIndex/3;
           

       }
       else
       {
           nextLevelPanels[(int)Random.Range(1f,2.9f)].SetActive(true);
           //her 3 bölümün 2sinde random bir sayı alıp int'e çeviriyor ve rastgele 2sinden birisi actif olmuş oluyor
       }
       foreach (GameObject panel in panels)
       {
           panel.SetActive(false);
       }
       panels[2].SetActive(true);
       isLevelCompleted = true;


   }
   public void StartGame()
   {
        for (int i = 0; i < panels.Count-1; i++)
        {
            panels[i].SetActive(false);
            
        }
        panels[1].SetActive(true);
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
