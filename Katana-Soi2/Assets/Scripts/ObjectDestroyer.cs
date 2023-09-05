using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log(collision.gameObject.name + " Die ");
        Invoke("RestartScene", 2f);
    }

    public void RestartScene()
    {
        // Scene will restart after two Seconds .
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
