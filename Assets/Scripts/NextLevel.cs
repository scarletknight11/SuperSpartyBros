using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour {

    public GameObject Level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            Level.SetActive(true);
        }
    }

    public void Next()
    {
        SceneManager.LoadScene("Next Level");
    }

}
