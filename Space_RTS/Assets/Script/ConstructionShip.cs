using System.Collections;
using UnityEngine;

public class ConstructionShip : ShipBase
{
	Coroutine curretCoroutine;

	float miningCD;
	float totalMiningCD;
	Vector2 targetPosition;
	Vector2 basePosition;

	GameObject isHeld = null;

	public ConstructionShip(float totalMiningCD, Vector3 targetPosition, int max_Hp, int def, float scanRange, string name, float spd, float totalAtkCd) : base(max_Hp,def,scanRange,name,spd,totalAtkCd) {
		this.totalMiningCD = totalMiningCD;
		if (targetPosition != null) { Move(targetPosition); }
	}
	protected override void Move(Vector3 position)
	{
		if (curretCoroutine != null) {
			StopCoroutine(curretCoroutine);
			curretCoroutine = null;
		}
		
		base.Move(position);
	}
	public void Mining(GameObject minable) {
		if (curretCoroutine != null)
		{
			StopCoroutine(curretCoroutine);
			curretCoroutine = null;
		}
		if (isHeld == minable)
		{

		}
		else {
			StartCoroutine(Mine(minable));
		}
		
	}
	private IEnumerator Mine(GameObject minable) {

		yield return new WaitForSeconds(totalMiningCD);

		//isHeld = gameObject;
	}
	private void Update()
	{
		
	}

}
