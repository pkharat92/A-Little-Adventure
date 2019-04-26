using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureChestControllerLevel2 : MonoBehaviour
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

            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCount > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        } // End if
    }
} // End class
