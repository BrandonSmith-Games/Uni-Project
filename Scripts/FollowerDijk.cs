using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Follower.
/// </summary>
//[ExecuteInEditMode]
public class FollowerDijk : MonoBehaviour
{

	[SerializeField]
	protected GraphTwo m_GraphTwo;
	[SerializeField]
	protected NodeTwo m_Start;
	[SerializeField]
	protected NodeTwo m_End;
	[SerializeField]
	protected float m_Speed = 0.01f;
	protected PathTwo m_PathTwo = new PathTwo ();
	protected NodeTwo m_Current;

	void Start ()
	{
		m_PathTwo = m_GraphTwo.GetShortestPathTwo ( m_Start, m_End );
		Follow ( m_PathTwo );
	}

	/// <summary>
	/// Follow the specified PathTwo.
	/// </summary>
	/// <param name="PathTwo">PathTwo.</param>
	public void Follow ( PathTwo PathTwo )
	{
		StopCoroutine ( "FollowPathTwo" );
		m_PathTwo = PathTwo;
		transform.position = m_PathTwo.NodeTwos [ 0 ].transform.position;
		StartCoroutine ( "FollowPathTwo" );
	}

	/// <summary>
	/// Following the PathTwo.
	/// </summary>
	/// <returns>The PathTwo.</returns>
	IEnumerator FollowPathTwo ()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.update += Update;
		#endif
		var e = m_PathTwo.NodeTwos.GetEnumerator ();
		while ( e.MoveNext () )
		{
			m_Current = e.Current;
			
			// Wait until we reach the current target NodeTwo and then go to next NodeTwo
			yield return new WaitUntil ( () =>
			{
				return transform.position == m_Current.transform.position;
			} );
		}
		m_Current = null;
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.update -= Update;
		#endif
	}

	void Update ()
	{
		if ( m_Current != null )
		{
			transform.position = Vector3.MoveTowards ( transform.position, m_Current.transform.position, m_Speed );
		}
	}
	
}
