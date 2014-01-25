using UnityEngine;
using System.Collections;

public class testBehavior : MonoBehaviour {
	//const int FrameMax = 360;
	//private int m_Frame;
	private bool colorSwitch = false;
	static int fireCount = 40;
	int fire = fireCount;
	NodeManager nodeManager = new NodeManager();
	public GameObject prefab;
	
	void Start () {
		//m_Frame = 0;
	}
	void Update () {
		Color color;
		
		if (fire == 0) {
			//Debug.Log(nodeManager.getNode().ToString());
			if (nodeManager.getNode() == 0) {
				color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
			} else {
				color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
			}
			this.renderer.material.SetColor("_Color", color);	
			fire = fireCount;
		} else {
			fire--;
		}
		
		//float red = Mathf.Sin((float)m_Frame/(float)FrameMax * Mathf.PI * 2.0f);
		//Color color = new Color(Mathf.Abs(red), 0.0f, 0.0f, 1.0f);
			
		//m_Frame++;
	}
}