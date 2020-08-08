﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitForSecond : MonoBehaviour
{
    //Global variable
    [SerializeField] private UnityEvent OnComplete;

    public void Wait(float seconds)
    {
        StartCoroutine(IeWaitForSecond(seconds));
    }

    private IEnumerator IeWaitForSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(OnComplete != null)
        {
            OnComplete.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
