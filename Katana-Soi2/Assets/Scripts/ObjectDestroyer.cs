using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject loseImage;
    [SerializeField] private GameObject gameElements;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Debug.Log(collision.gameObject.name + " Die ");
            Invoke("GameOver", 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        loseImage.SetActive(true);
        gameElements.SetActive(false);
        // Scene will restart after two Seconds .
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
