using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SleepTimer());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SleepTimer()
    {
        yield return new WaitForSeconds(4);
        Application.Quit();
    }
}
