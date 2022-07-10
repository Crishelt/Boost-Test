using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    const float tau = Mathf.PI * 2;
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Abs(Mathf.Sin(cycles * tau)); //bouncy like
        rawSinWave = (Mathf.Sin(cycles * tau) + 1f) / 2f; //smooth like

        Vector3 offset = rawSinWave * movementFactor * movementVector;
        transform.position = startingPosition + offset;
    }
}
