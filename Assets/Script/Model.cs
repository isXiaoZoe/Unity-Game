using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Model: MonoBehaviour {
    private int BestScore;
    private int CurScore;
    private string scorePath;
    private string posPath;

    public Text curScoreInPlay;
    public Text curScoreInEnd;
    public Text bestScoreInPlay;
    public Text bestScoreInEnd;

    private void Awake()
    {
        scorePath = Application.dataPath + @"\Data\MaxScore.txt";
        posPath = Application.dataPath + @"\Data\lastData.txt";
        initTxt();
        ReadBestScore();
    }

    private void initTxt()
    {
        if (!File.Exists(scorePath))
        {
            File.Create(scorePath).Dispose();
        }
        if (!File.Exists(posPath))
        {
            File.Create(posPath).Dispose();
        }
    }

    private void ReadBestScore()
    {
        string score = File.ReadAllText(scorePath);
        if (score.Length != 0)
        {
            BestScore = int.Parse(score);
        }else
        {
            BestScore = 0;
        }
    }

    public void init()
    {
        CurScore = 0;
        curScoreInPlay.text = CurScore.ToString();
        bestScoreInPlay.text = BestScore.ToString();
    }

    public void addScore()
    {
        ++CurScore;
        curScoreInPlay.text = CurScore.ToString();
    }

    public void showScoreInEndView()
    {
        if (CurScore > BestScore)
        {
            BestScore = CurScore;
            File.WriteAllText(scorePath, BestScore.ToString());
        }
        curScoreInEnd.text = CurScore.ToString();
        bestScoreInEnd.text = BestScore.ToString();
    }

    public string[] ReadPos()
    {
        string[] pos = File.ReadAllLines(posPath);
        return pos;
    }

    public void WritePos(string[] pos)
    {
        File.WriteAllLines(posPath, pos);
    }
    
    public void clear()
    {
        File.WriteAllText(posPath, "");
    }
}
