using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureChestController : MonoBehaviour
{
    public Animator animator;
    private bool collided = false;
    private GameObject[] gos;

    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = false;
    } // End start

    // Update is called once per frame
    void Update()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy");
    } // End update

    public void openChest()
    {
        if (gos.Length == 0)
        {
            // Unlock chest
            animator.enabled = true;

            string currentScene;
            currentScene = SceneManager.GetActiveScene().name;

            switch (currentScene)
            {
                case "Level 1":
                    SceneManager.LoadScene("Level 2");
                    break;

                case "Level 2":
                    SceneManager.LoadScene("credits");
                    break;
            }
        } // End if
    }
} // End class
