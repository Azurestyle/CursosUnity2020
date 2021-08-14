using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public GameObject player;
    // Start is called before the first frame update

    private bool isPlayerAtExit;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;

        }
    }

    private void Update()
    {
        if (isPlayerAtExit)
        {
            timer += Time.deltaTime;
            exitBackgroundImageCanvasGroup.alpha = timer / fadeDuration; //conceptualmente el alpha solo llega a 1, y esto puede ser mayor a 1, en principio no pasa nada pero si saltan las alarmas, se puede poner un mathf.clamp de 0,1
            if (timer > fadeDuration + displayImageDuration)
            {
                EndLevel();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void EndLevel()
    {
        Application.Quit();
    }
}
