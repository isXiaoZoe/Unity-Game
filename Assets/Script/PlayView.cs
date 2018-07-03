using System.Collections;
using UnityEngine;

public class PlayView : MonoBehaviour {

    private Player player;
    private Pedal[] pedals;
    public Color[] colors;

	void Awake () {
        player = GetComponentInChildren<Player>();
        pedals = GetComponentsInChildren<Pedal>();
	}

    public void init()
    {
        StartCoroutine(setPedalPos());
    }

    private IEnumerator setPedalPos()
    {
        player.gameObject.SetActive(false);

        float X;
        int n = 0;
        int len = colors.Length;
        
        foreach(Pedal p in pedals)
        {
            X = n * 2.175f;
            p.init(colors[Random.Range(0, len)], X);
            yield return 0;
            n = (n == 3 ? 0 : ++n);
        }
        foreach(Pedal p in pedals)
        {
            p.setSpeed();
        }
        player.gameObject.SetActive(true);
    }

    public void reset()
    {
        player.reset();
        foreach(Pedal p in pedals)
        {
            p.reset();
        }
    }

    public string[] getAllPos()
    {
        string[] pos = new string[pedals.Length];
        for(int i = 0; i < pedals.Length; ++i)
        {
            pos[i] = pedals[i].getPos();
        }
        return pos;
    }

    public void setPos(string[] allPos)
    {
        for(int i = 0; i < allPos.Length; ++i)
        {
            string[] pos = allPos[i].Split(' ');
            pedals[i].transform.position = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), 1);
            pedals[i].setSpeed();
        }
    }
}
