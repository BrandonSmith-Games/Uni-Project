using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomEditor ( typeof ( GraphTwo ) )]
public class GraphTwoEditor : Editor
{
	
	protected GraphTwo m_GraphTwo;
	protected NodeTwo m_From;
	protected NodeTwo m_To;
	protected FollowerDijk m_FollowerDijk;
	protected PathTwo m_PathTwo = new PathTwo ();

	void OnEnable ()
	{
		m_GraphTwo = target as GraphTwo;
	}

	void OnSceneGUI ()
	{
		if ( m_GraphTwo == null )
		{
			return;
		}
		for ( int i = 0; i < m_GraphTwo.NodeTwos.Count; i++ )
		{
			NodeTwo NodeTwo = m_GraphTwo.NodeTwos [ i ];
			for ( int j = 0; j < NodeTwo.connections.Count; j++ )
			{
				NodeTwo connection = NodeTwo.connections [ j ];
				if ( connection == null )
				{
					continue;
				}
				float distance = Vector3.Distance ( NodeTwo.transform.position, connection.transform.position );
				Vector3 diff = connection.transform.position - NodeTwo.transform.position;
				Handles.Label ( NodeTwo.transform.position + ( diff / 2 ), distance.ToString (), EditorStyles.whiteBoldLabel );
				if ( m_PathTwo.NodeTwos.Contains ( NodeTwo ) && m_PathTwo.NodeTwos.Contains ( connection ) )
				{
					Color color = Handles.color;
					Handles.color = Color.green;
					Handles.DrawLine ( NodeTwo.transform.position, connection.transform.position );
					Handles.color = color;
				}
				else
				{
					Handles.DrawLine ( NodeTwo.transform.position, connection.transform.position );
				}
			}
		}
	}

	public override void OnInspectorGUI ()
	{
		m_GraphTwo.NodeTwos.Clear ();
		foreach ( Transform child in m_GraphTwo.transform )
		{
			NodeTwo NodeTwo = child.GetComponent<NodeTwo> ();
			if ( NodeTwo != null )
			{
				m_GraphTwo.NodeTwos.Add ( NodeTwo );
			}
		}
		base.OnInspectorGUI ();
		EditorGUILayout.Separator ();
		m_From = ( NodeTwo )EditorGUILayout.ObjectField ( "From", m_From, typeof ( NodeTwo ), true );
		m_To = ( NodeTwo )EditorGUILayout.ObjectField ( "To", m_To, typeof ( NodeTwo ), true );
		m_FollowerDijk = ( FollowerDijk )EditorGUILayout.ObjectField ( "FollowerDijk", m_FollowerDijk, typeof ( FollowerDijk ), true );
		if ( GUILayout.Button ( "Show Shortest PathTwo" ) )
		{
			m_PathTwo = m_GraphTwo.GetShortestPathTwo ( m_From, m_To );
			if ( m_FollowerDijk != null )
			{
				m_FollowerDijk.Follow ( m_PathTwo );
				Debug.Log("worked");
			}
			else{Debug.Log("broke");}
		
			Debug.Log ( m_PathTwo );
			SceneView.RepaintAll ();
		}
		
	}
	
}
