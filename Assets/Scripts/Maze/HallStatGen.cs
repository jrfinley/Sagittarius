using UnityEngine;
using System.Collections;

public class HallStatGen : MonoBehaviour 
{
	public float requiredStr;
	public float requiredInt;
	public float requiredDex;

	public bool isEmpty;
	public bool isDoor;
	public bool isHinge;
	public bool isLock;

	public GameObject thisLock;
	public GameObject thisHinge;
	public GameObject thisDoor; 

	void Start () 
	{
		decideHallway();
	}

	void decideHallway()
	{
		isEmpty = Random.value >= 0.3;
		if(isEmpty)
		{

		} 
		else 
		{
            isDoor = Random.value >= 0.5;

				if(isDoor)
				{
					requiredStr = Random.Range (5, 20);
				}
			else
			{
                isHinge = Random.value >= 0.5;

				if (isHinge)
				{
					requiredInt = Random.Range (5, 20);
				}

				else
				{
                    isLock = true;
					requiredDex = Random.Range (5, 20);
				}	
			
			}

		}
	
	}

}
