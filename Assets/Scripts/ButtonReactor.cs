﻿using UnityEngine;
using UnityEngine.Events;
using VRTK;
using VRTK.UnityEventHelper;

public class ButtonReactor : MonoBehaviour
{

    public UnityEvent OnPush;


    private VRTK_Button_UnityEvents buttonEvents;

    private void Start()
    {
        buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
        if (buttonEvents == null)
        {
            buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
        }
        buttonEvents.OnPushed.AddListener(handlePush);
    }

    private void handlePush(object sender, Control3DEventArgs e)
    {
        VRTK_Logger.Info("Pushed");
        OnPush.Invoke();
    }
}