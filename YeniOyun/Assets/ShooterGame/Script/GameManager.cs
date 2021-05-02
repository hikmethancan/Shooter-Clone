using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
      if(GameObject.FindGameObjectWithTag("Enemy")==null)
      LevelCompleted();

   }

   public void GameOverPanelON(){gameOverPanel.gameObject.SetActive(true);}
   public void GameOverPanelOFF(){gameOverPanel.gameObject.SetActive(false);}

   public void InGamePanelON(){inGamePanel.gameObject.SetActive(true);}
   public void InGamePanelOFF(){inGamePanel.gameObject.SetActive(false);}

   public void StartPanelON(){startPanel.gameObject.SetActive(true);}
   public void StartPanelOFF(){startPanel.gameObject.SetActive(false);}

   public void NextLevelPanelON(){nextLevelPanel.gameObject.SetActive(true);}
   public void NextLevelPanelOFF(){nextLevelPanel.gameObject.SetActive(false);}

   public void InfoPanelON(){infoPanel.gameObject.SetActive(true);}
   public void InfoPanelOFF(){infoPanel.gameObject.SetActive(false);}




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
