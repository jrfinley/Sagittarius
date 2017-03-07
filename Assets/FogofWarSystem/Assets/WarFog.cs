using UnityEngine;
using System.Collections;

public class WarFog : MonoBehaviour 
{
    public Material unSeen;
    public Material haveSeen;
    public Material seeing;
    public Renderer rend;

	public float duration = 2.0f;

	void Start () 
	{
        rend = GetComponent<Renderer>();
        rend.material = unSeen;
    }
	
	void Update () 
	{

	}

    public void OnTriggerEnter(Collider other)
    {
		BrightenRoom();
	}
  
	public void OnTriggerExit(Collider other)
    {
		DimRoom();
    }
  
	public void BrightenRoom()
	{
		float lerp = Mathf.PingPong (Time.time, duration) /duration ;
		rend.material.Lerp (unSeen, seeing, lerp);

	}

	public void DimRoom()
	{
		float lerp = Mathf.PingPong (Time.time, duration) /duration ;
		rend.material.Lerp (seeing, haveSeen, lerp);
	}
}
