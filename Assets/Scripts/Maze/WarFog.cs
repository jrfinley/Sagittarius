using UnityEngine;
using System.Collections;

public class WarFog : MonoBehaviour 
{
    public Material unSeen;
    public Material haveSeen;
    public Material seeing;
    public Renderer rend;

	void Start () 
	{
        rend = GetComponent<Renderer>();
        rend.material = unSeen;
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
        rend.material = seeing;
	}

	public void DimRoom()
	{       
        rend.material = haveSeen;      
	}
}
