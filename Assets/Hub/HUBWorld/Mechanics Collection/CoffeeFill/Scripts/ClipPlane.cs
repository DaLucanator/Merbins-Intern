using UnityEngine;

[ExecuteInEditMode]
public class ClipPlane : MonoBehaviour 
{
	public Material PlaneClipMat; 
	private Transform m_transform;
	void Start () 
	{
		m_transform = transform;
	}
	
	void Update () 
	{
		Plane plane = new Plane( m_transform.up, m_transform.position );
		Vector4 planeNormals = new Vector4( plane.normal.x, plane.normal.y, plane.normal.z, plane.distance );

		if (PlaneClipMat != null)
		{
			this.PlaneClipMat.SetVector("_PlaneNormal", planeNormals);
			this.PlaneClipMat.SetVector("_PlanePosition", m_transform.position);
		}
	}
}
