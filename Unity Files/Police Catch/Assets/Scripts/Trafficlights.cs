using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trafficlights : MonoBehaviour
{
    public List<GameObject> lights = new List<GameObject>();

    bool isCounting;
    int lightnumber;
    int lightnumber2;
    int count;

	void Start ()
    {
        count = lights.Count;
        count--;
        isCounting = false;
        lightnumber = 0;
	}
	
	void Update ()
    {
		if(isCounting == false)
        {
            StartCoroutine(TurnLightsOn());
            isCounting = true;
        }
	}

    public IEnumerator TurnLightsOn()
    {
        yield return new WaitForSeconds(3);
        lights[lightnumber].SetActive(true);

        TurnLightsOff();
        Debug.Log(lightnumber);
    }

    void TurnLightsOff()
    {
        lightnumber2 = lightnumber;
        lightnumber2--;

        if (lightnumber == 0)
        {
            lights[count].SetActive(false);
        }
        else { Debug.Log("i--?"); lights[lightnumber2].SetActive(false); Debug.Log(lightnumber); }

        SwitchLights();
    }

    void SwitchLights()
    {
        if(lightnumber >= count)
        {
            lightnumber = 0;
            Debug.Log("i=0");
        }
        else { lightnumber++; Debug.Log("i++"); }

        isCounting = false;
    }
}