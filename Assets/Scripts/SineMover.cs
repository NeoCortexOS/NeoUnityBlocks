using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMover: MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    [SerializeField] private float startFactor;
    [SerializeField] private bool showDebug = false;
 
    Vector3 startingPosition;
    float movementFactor;
    float myTime = 0f;
    const float tau = Mathf.PI * 2;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } // do nothing if period = 0

        // since sinewave starts at 0, goes thru positive and back,
        // adding 0.75f gives the first position of -1, which should be the resting position of our object
        // startFactor / 2 gives the relative starting position, as 1 would be a full cycle
        float cycles = (myTime / period) + 0.75f + (startFactor / 2);
        // going from -1 to 1, factor tau stretches it to realtime
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave + 1f) / 2f; // rescale to 0 - 1
        if (showDebug)
        {
            Debug.Log(movementFactor + " " + myTime + " cycles: " + cycles + " rawSinWave: " + rawSinWave);
        }
        transform.position = startingPosition + (movementVector * movementFactor);
        myTime += Time.deltaTime;
    }
}
