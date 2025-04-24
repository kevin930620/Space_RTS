using UnityEngine;
using System.Collections.Generic;
public class UnitUIAction : MonoBehaviour
{
	int menuState = 0;
	[SerializeField]
	List<GameObject> menuList = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetActionMenu(int state)
	{
		Debug.Log(state);
		menuState = state;
		ActionClear();
		menuList[menuState].SetActive(true);
	}
	public void ActionClear()
	{
		foreach (GameObject go in menuList)
		{
			if(go!=null)go.SetActive(false);
		}
	}
}
