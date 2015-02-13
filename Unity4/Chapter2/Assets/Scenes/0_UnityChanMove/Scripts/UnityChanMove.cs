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
        //unityChanPrefab.rigidbody.AddForce(unityChanPrefab.transform.forward * (v * 1000f) * Time.deltaTime, ForceMode.Acceleration);

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetTrigger("jumping");
		}

	    if (v > 0f)
	    {
	        if (Input.GetKey(KeyCode.LeftShift))
	        {
	            anim.SetBool("dash", true);
	        }
	        else if (Input.GetKeyUp(KeyCode.LeftShift))
	        {
	            anim.SetBool("dash", false);
	        }
	    }
        else
        {
            anim.SetBool("dash", false);
        }
	}
}
