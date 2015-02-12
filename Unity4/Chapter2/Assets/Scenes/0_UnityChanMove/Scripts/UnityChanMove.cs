using UnityEngine;
using System.Collections;

public class UnityChanMove : MonoBehaviour {

	public GameObject unityChanPrefab;

	/// <summary>
	/// The UnityChan animation.
	/// </summary>
	private Animator anim;

	private Vector3 vec;

	// Use this for initialization
	void Start () {
		anim = unityChanPrefab.GetComponent<Animator> ();
		vec = unityChanPrefab.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", v);
		anim.SetFloat ("turn", h);

		unityChanPrefab.transform.position += unityChanPrefab.transform.forward * v * Time.deltaTime;
		unityChanPrefab.transform.Rotate (0, 100f * h * Time.deltaTime, 0);

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetTrigger("jumping");
		}

//		if (v != 0f) {
//			vec.z+= (v > 0 ? 0.01f : -0.01f);
//			Debug.Log (vec.x + "," + vec.y + "," + vec.z);
//			unityChanPrefab.transform.position = vec;
//		}
//
//		float h = Input.GetAxis ("Horizontal");
//		anim.SetFloat ("turn", h);
//		if (h != 0f) {
//			unityChanPrefab.transform.Rotate(0f,(h > 0 ? 1f : -1f),0f);
//		}
	}
}
