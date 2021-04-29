using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameObject oyunBitti;
    [SerializeField]
    GameObject tekrarOyna;

    [SerializeField]
    GameObject oynaButonu = default;

    void Start()
    {
        oyunBitti.gameObject.SetActive(false);
        tekrarOyna.gameObject.SetActive(false);
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        oynaButonu.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
