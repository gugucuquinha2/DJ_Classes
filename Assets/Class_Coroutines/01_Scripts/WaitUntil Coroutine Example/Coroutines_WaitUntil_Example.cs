using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines_WaitUntil_Example : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForObject());

        // Even if the coroutine is still running this code will still run, because its happening outside of the coroutine
        Debug.Log("Any other code");
    }

    private IEnumerator WaitForObject()
    {
        Debug.Log("Start looking for the cube!");

        // "WaitUntil" waits until the condition we defined (cube.activeSelf == true) happens
        // only then it will move on and run the code after the "yield return":
        // - hit play and activate the cube in the Inspector to see the example working

        // NOTE: Keep in mind that any other code outside this coroutine will keep running even if the coroutine is paused
        yield return new WaitUntil(() => cube.activeSelf == true);

        Debug.Log("Found the cube!");
    }
}
