using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The PathTwo.
/// </summary>
public class PathTwo
{

	/// <summary>
	/// The NodeTwos.
	/// </summary>
	protected List<NodeTwo> m_NodeTwos = new List<NodeTwo> ();
	
	/// <summary>
	/// The length of the PathTwo.
	/// </summary>
	protected float m_Length = 0f;

	/// <summary>
	/// Gets the NodeTwos.
	/// </summary>
	/// <value>The NodeTwos.</value>
	public virtual List<NodeTwo> NodeTwos
	{
		get
		{
			return m_NodeTwos;
		}
	}

	/// <summary>
	/// Gets the length of the PathTwo.
	/// </summary>
	/// <value>The length.</value>
	public virtual float length
	{
		get
		{
			return m_Length;
		}
	}

	/// <summary>
	/// Bake the PathTwo.
	/// Making the PathTwo ready for usage, Such as caculating the length.
	/// </summary>
	public virtual void Bake ()
	{
		List<NodeTwo> calculated = new List<NodeTwo> ();
		m_Length = 0f;
		for ( int i = 0; i < m_NodeTwos.Count; i++ )
		{
			NodeTwo NodeTwo = m_NodeTwos [ i ];
			for ( int j = 0; j < NodeTwo.connections.Count; j++ )
			{
				NodeTwo connection = NodeTwo.connections [ j ];
				
				// Don't calcualte calculated NodeTwos
				if ( m_NodeTwos.Contains ( connection ) && !calculated.Contains ( connection ) )
				{
					
					// Calculating the distance between a NodeTwo and connection when they are both available in PathTwo NodeTwos list
					m_Length += Vector3.Distance ( NodeTwo.transform.position, connection.transform.position );
				}
			}
			calculated.Add ( NodeTwo );
		}
	}

	/// <summary>
	/// Returns a string that represents the current object.
	/// </summary>
	/// <returns>A string that represents the current object.</returns>
	/// <filterpriority>2</filterpriority>
	public override string ToString ()
	{
		return string.Format (
			"NodeTwos: {0}\nLength: {1}",
			string.Join (
				", ",
				NodeTwos.Select ( NodeTwo => NodeTwo.name ).ToArray () ),
			length );
	}
	
}
