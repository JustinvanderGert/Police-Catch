using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBar : MonoBehaviour
{
    public float barDisplay;
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    public GameObject dealer;

    void Start()
    {
        pos.x = 0;
    }

	void OnGUI()
    {
        GUI.BeginGroup(new Rect(pos.x, pos.y, pos.x, pos.y));
        GUI.Box(new Rect(0,0, size.x, size.y), fullTex);

        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);

        GUI.EndGroup();
        GUI.EndGroup();
	}
	
	void Update ()
    {
        dealer = GameObject.FindGameObjectWithTag("Dealer");
        if (pos.x == 400)
        {
            barDisplay = dealer.GetComponent<Dealer>().totalClicks / 10;
        }
	}
    public void StopBar()
    {
        pos.x = 0;
    }
    public void StartBar()
    {
        pos.x = 400;
    }
}