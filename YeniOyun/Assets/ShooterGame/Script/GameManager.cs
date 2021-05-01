using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public GameObject joyStickPanel;
   public GameObject gameOverPanel;
   public GameObject startPanel;
   public GameObject nextLevelPanel;


   GameObject[] EnemyList;

   void Start()
   {
      EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
   }

   public void GameOverPanelON(){gameOverPanel.gameObject.SetActive(true);}
   public void GameOverPanelOFF(){gameOverPanel.gameObject.SetActive(false);}

   public void JoyStickPanelON(){joyStickPanel.gameObject.SetActive(true);}
   public void JoyStickPanelOFF(){joyStickPanel.gameObject.SetActive(false);}

   public void StartPanelON(){startPanel.gameObject.SetActive(true);}
   public void StartPanelOFF(){startPanel.gameObject.SetActive(false);}

   public void NextLevelPanelON(){nextLevelPanel.gameObject.SetActive(true);}
   public void NextLevelPanelOFF(){nextLevelPanel.gameObject.SetActive(false);}




   public void GameOver(GameObject friend){
      Destroy(friend.gameObject);
      JoyStickPanelOFF();
      GameOverPanelON();
   }
   public void HitEnemy(GameObject enemy){
      Destroy(enemy.gameObject);
      JoyStickPanelOFF();
      NextLevelPanelON();
   }

   public void Restart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void StartGame()
   {
      StartPanelOFF();
      JoyStickPanelON();
   }

   public void NextLevel()
   {

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }


}
