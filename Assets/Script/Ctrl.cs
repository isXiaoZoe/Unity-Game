using System;
using UnityEngine;

public class Ctrl : MonoBehaviour {

    public static bool isBack;
    public static Action IsOver { get; private set; }
    public static Action UpdateScore { get; private set; }
    
    public GameObject beginView;
    public GameObject endView;
    public PlayView playview;
    public Model model;

    void Start()
    {
        isBack = false;
        IsOver = toEndView;
        UpdateScore = model.addScore;
    }

    public void onBtnPlay()
    {
        beginView.SetActive(false);
        playview.gameObject.SetActive(true);

        playview.reset();
        playview.init();
        model.init();
    }

    public void onBtnContinue()
    {
       string[] allPos = model.ReadPos();

       beginView.SetActive(false);
       playview.gameObject.SetActive(true);

       if (allPos.Length != 0)
       {
            playview.setPos(allPos);
       }
       else
       {
           playview.reset();
           playview.init();
            model.init();
       }
    }

    public void onPlayViewBack()
    {
        isBack = true;
        playview.gameObject.SetActive(false);
        beginView.SetActive(true);

        model.WritePos(playview.getAllPos());
    }

    public void toEndView()
    {
        playview.gameObject.SetActive(false);
        endView.SetActive(true);

        model.showScoreInEndView();
        model.clear();
    }

    public void onBtnReplay()
    {
        endView.SetActive(false);  
        playview.gameObject.SetActive(true);

        playview.reset();
        playview.init();
        model.init();
    }

    public void onBtnEndViewBack()
    {
        endView.SetActive(false);
        beginView.SetActive(true);
    }

    public void onBtnExit()
    {
        model.clear();
        Application.Quit();
    }
}
