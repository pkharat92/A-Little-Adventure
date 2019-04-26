using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureChestControllerLevel1 : MonoBehaviour
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
        Debug.Log(gos.Length);
    } // End update

    private void OnCollisonEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("collision");
        }
    } // End OnCollisionEnter2D()

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("stay");
            if (Input.GetKeyDown(KeyCode.Z) && gos.Length == 0)
            {
                // Unlock chest
                animator.enabled = true;

                //Load next level
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if(SceneManager.sceneCount > nextSceneIndex)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
            } // End if
        } // End if
    } // End OnCollisionStay2D()
} // End class
