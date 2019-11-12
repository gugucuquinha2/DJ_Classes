using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines_CoroutineVsMethod_Example : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Method();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(Coroutine());
        }
    }

    private void Method()
    {
        // the start value
        float value = 1;

        // while our value  is bigger than 0...
        while (value > 0)
        {
            // ...we remove "0.1" for every frame it stays bigger than 0
            value -= 0.1f;

            Debug.Log(value);
        }

        // usually in a regular method, a program simply runs all iterations of its code within the same frame, its istant.
        // if there's too many iterations, a method will block the program, until all iterations are done
    }

    private IEnumerator Coroutine()
    {   // the start value
        float value = 1;

        // while our value  is bigger than 0...
        while (value > 0)
        {
            // ...we remove "0.1" for every frame it stays bigger than 0
            value -= 0.1f;

            Debug.Log(value);

            // before moving on to the next while condition verification, the coroutine will WAIT 0.1 seconds
            // this means that this our value will take 1 second (0.1 / 0.1 = 1) to get the "value" to 0
            yield return new WaitForSeconds(0.1f);
        }

        // with coroutines we use "yield return" statements to determine how much time/frames the program will wait, until moving on to the next iteration or piece of code
    }
}
