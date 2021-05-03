using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public GameObject inGamePanel;
   public GameObject gameOverPanel;
   public GameObject startPanel;
   public GameObject nextLevelPanel;
   public GameObject infoPanel;

   
   GunScript gunScript;

   GameObject[] EnemyList;

   void Start()
   {
      gunScript = FindObjectOfType<GunScript>();
      EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
   }

   void Update()
   {
      if(GameObject.FindGameObjectWithTag("Bullet")==null && gunScript.ammo == 0 && GameObject.FindGameObjectWithTag("Enemy")!=null)
      GameOver();
        if (GameObject.FindGameObjectWithTag("Enemy") == null) { 
            PlayerAnimation.win();
            LevelCompleted();
        }
    }

   public void GameOverPanelON(){gameOverPanel.SetActive(true);}
   public void GameOverPanelOFF(){gameOverPanel.SetActive(false);}

   public void InGamePanelON(){inGamePanel.SetActive(true);}
   public void InGamePanelOFF(){inGamePanel.SetActive(false);}

   public void StartPanelON(){startPanel.SetActive(true);}
   public void StartPanelOFF(){startPanel.SetActive(false);}

   public void NextLevelPanelON(){nextLevelPanel.SetActive(true);}
   public void NextLevelPanelOFF(){nextLevelPanel.SetActive(false);}

   public void InfoPanelON(){infoPanel.SetActive(true);}
   public void InfoPanelOFF(){infoPanel.SetActive(false);}




   public void GameOver(){
      InfoPanelOFF();
      InGamePanelOFF();
      GameOverPanelON();
      Invoke("Restart",3);
   }

   public void LevelCompleted()
   {
      InGamePanelOFF();
      InfoPanelOFF();
      NextLevelPanelON();
   }

   public void StartGame()
   {
      StartPanelOFF();
      InGamePanelON();
      InfoPanelON();
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
