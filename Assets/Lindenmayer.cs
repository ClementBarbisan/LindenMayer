using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lindenmayer : MonoBehaviour {
	public string current;
	public int iterations = 1;
	public List<string> nameRules;
	public List<string> listRules;
	private Dictionary<string, string> rules;
	private LineRenderer line;
	private List<Vector3> listPositions;
	private List<Vector3> listVertices;
	private List<int> listTriangles;
	public float angle = 90;
	private Mesh mesh;
	// Use this for initialization
	void Start () 
	{
		mesh = new Mesh ();
		GetComponent<SkinnedMeshRenderer> ().sharedMesh = mesh;
		line = GetComponent<LineRenderer> ();
		rules = new Dictionary<string, string> ();
		listPositions = new List<Vector3> ();
		listVertices = new List<Vector3> ();
		listTriangles = new List<int> ();
		listVertices.Add (new Vector3(-0.1f, 0.0f, 0.1f));
		listVertices.Add (new Vector3(0.0f, 0.1f, -0.1f));
		listVertices.Add (new Vector3(0.1f, 0.0f, -0.1f));
		listVertices.Add (new Vector3(0.0f, -0.1f, 0.1f));
		listTriangles.Add (0);
		listTriangles.Add (3);
		listTriangles.Add (2);
		listTriangles.Add (0);
		listTriangles.Add (2);
		listTriangles.Add (1);
		listPositions.Add (transform.position);
		for (int i = 0; i < nameRules.Count; i++)
		{
			rules.Add (nameRules[i], listRules[i]);
		}
		while (iterations > 0)
		{
			string tmp = current;
			current = "";
			for (int i = 0; i < tmp.Length; i++)
			{
				if (nameRules.Contains (tmp [i].ToString()))
					current += rules [tmp [i].ToString()];
				else
					current += tmp [i];
			}
			iterations--;
		}
		for (int i = 0; i < current.Length; i++)
		{
			if (current[i] == '+')
			{
				transform.Rotate (angle, 0.0f, 0.0f);
				Debug.Log ("Turn on y axis of 90 degrees");
			}
			else if (current[i] == '-')
			{
				transform.Rotate (-angle, 0.0f, 0.0f);
				Debug.Log ("Turn on y axis of -90 degrees");
			}
			else if (current[i] == '&')
			{
				transform.Rotate (0.0f, angle, 0.0f);
				Debug.Log ("Turn on x axis of 90 degrees");
			}
			else if (current[i] == '#')
			{
				transform.Rotate (0.0f, -angle, 0.0f);
				Debug.Log ("Turn on x axis of -90 degrees");
			}
			else if (current[i] == '\\')
			{
				transform.Rotate (0.0f, 0.0f, angle);
				Debug.Log ("Turn on z axis of 90 degrees");
			}
			else if (current[i] == '/')
			{
				transform.Rotate (0.0f, 0.0f, -angle);
				Debug.Log ("Turn on z axis of -90 degrees");
			}
			else if (current[i] == '|')
			{
				transform.Rotate (180f, 0.0f, 0.0f);
				Debug.Log ("Turn on y axis of 180 degrees");
			}
			else if (current[i] == 'F')
			{
				int tmpCount = 0;
				transform.position += transform.forward;
				listVertices.Add (listVertices[listVertices.Count - 4] + transform.forward);
				listVertices.Add (listVertices[listVertices.Count - 4] + transform.forward);
				listVertices.Add (listVertices[listVertices.Count - 4] + transform.forward);
				listVertices.Add (listVertices[listVertices.Count - 4] + transform.forward);
				tmpCount = listVertices.Count;
				listTriangles.Add (tmpCount - 8);
				listTriangles.Add (tmpCount - 4);
				listTriangles.Add (tmpCount - 1);
				listTriangles.Add (tmpCount - 8);
				listTriangles.Add (tmpCount - 1);
				listTriangles.Add (tmpCount - 5);
				listTriangles.Add (tmpCount - 5);
				listTriangles.Add (tmpCount - 1);
				listTriangles.Add (tmpCount - 6);
				listTriangles.Add (tmpCount - 1);
				listTriangles.Add (tmpCount - 2);
				listTriangles.Add (tmpCount - 6);
				listTriangles.Add (tmpCount - 7);
				listTriangles.Add (tmpCount - 2);
				listTriangles.Add (tmpCount - 3);
				listTriangles.Add (tmpCount - 7);
				listTriangles.Add (tmpCount - 6);
				listTriangles.Add (tmpCount - 2);
				listTriangles.Add (tmpCount - 8);
				listTriangles.Add (tmpCount - 7);
				listTriangles.Add (tmpCount - 4);
				listTriangles.Add (tmpCount - 7);
				listTriangles.Add (tmpCount - 3);
				listTriangles.Add (tmpCount - 4);
				listPositions.Add(transform.position);
				Debug.Log ("Trace");
			}
		}
		int countTri = listVertices.Count;
		listTriangles.Add (countTri - 4);
		listTriangles.Add (countTri - 3);
		listTriangles.Add (countTri - 1);
		listTriangles.Add (countTri - 3);
		listTriangles.Add (countTri - 2);
		listTriangles.Add (countTri - 1);
		mesh.vertices = listVertices.ToArray ();
		mesh.triangles = listTriangles.ToArray();
		line.numPositions = listPositions.Count;
		line.SetPositions (listPositions.ToArray ());
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
