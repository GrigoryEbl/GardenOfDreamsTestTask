using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool _isWork;

    public Action TimeEmpty;

    public float Time { get; private set; }

    private void Update()
    {
        if (_isWork)
        {
            Time -= UnityEngine.Time.deltaTime;

            if (Time <= 0)
            {
                TimeEmpty?.Invoke();
                _isWork = false;
            }
        }
    }

    public void StartWork(float startTime)
    {
        if (Time > 0)
            return;

        Time = startTime;
        _isWork = true;
    }
}
