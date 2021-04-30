using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOScript : MonoBehaviour
{
   
    public void Replay()
    {
       
        SceneManager.LoadScene(Bullet.scenenumber);
    }
    
}
