using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ConstructionShip : ShipBase
{

	Coroutine curretCoroutine;

	float miningCD;
	float totalMiningCD;
	[SerializeField]
	Transform TargetUnit;
	[SerializeField]
	Vector3 targetPosition;
	Vector2 basePosition;

	public LayerMask ground;

	GameObject isHeld = null;

	public ConstructionShip(ShipBase shipInfo) : base(shipInfo)
	{
	}

	//public ConstructionShip(float totalMiningCD, Vector3 targetPosition, float spd, float atkRange, float totalAtkCd, int max_Hp, int def, float scanRange, string unitName) :
	//	base(spd, atkRange, totalAtkCd, max_Hp,def,scanRange, unitName) {
	//	this.totalMiningCD = totalMiningCD;

	//}
	private void Awake()
	{
		
	}
	private void Start()
	{

	}
	public override void Move(Vector3 position)
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
	protected override void Update()
	{
		base.Update();
	}
	private void FixedUpdate()
	{
		//AutoScan();	
	}
	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		base.OnTriggerEnter2D(collision);
	}
	protected override void OnTriggerExit2D(Collider2D collision)
	{
		base.OnTriggerExit2D(collision);
	}
	//protected override void AutoScan()
	//{
	//	//base.AutoScan();
	//}
}
