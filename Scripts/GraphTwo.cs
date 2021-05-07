using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The GraphTwo.
/// </summary>
public class GraphTwo : MonoBehaviour
{

	/// <summary>
	/// The NodeTwos.
	/// </summary>
	[SerializeField]
	protected List<NodeTwo> m_NodeTwos = new List<NodeTwo> ();

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
	/// Gets the shortest PathTwo from the starting NodeTwo to the ending NodeTwo.
	/// </summary>
	/// <returns>The shortest PathTwo.</returns>
	/// <param name="start">Start NodeTwo.</param>
	/// <param name="end">End NodeTwo.</param>
	public virtual PathTwo GetShortestPathTwo ( NodeTwo start, NodeTwo end )
	{
		
		// We don't accept null arguments
		if ( start == null || end == null )
		{
			throw new ArgumentNullException ();
		}
		
		// The final PathTwo
		PathTwo PathTwo = new PathTwo ();

		// If the start and end are same NodeTwo, we can return the start NodeTwo
		if ( start == end )
		{
			PathTwo.NodeTwos.Add ( start );
			return PathTwo;
		}
		
		// The list of unvisited NodeTwos
		List<NodeTwo> unvisited = new List<NodeTwo> ();
		
		// Previous NodeTwos in optimal PathTwo from source
		Dictionary<NodeTwo, NodeTwo> previous = new Dictionary<NodeTwo, NodeTwo> ();
		
		// The calculated distances, set all to Infinity at start, except the start NodeTwo
		Dictionary<NodeTwo, float> distances = new Dictionary<NodeTwo, float> ();
		
		for ( int i = 0; i < m_NodeTwos.Count; i++ )
		{
			NodeTwo NodeTwo = m_NodeTwos [ i ];
			unvisited.Add ( NodeTwo );
			
			// Setting the NodeTwo distance to Infinity
			distances.Add ( NodeTwo, float.MaxValue );
		}
		
		// Set the starting NodeTwo distance to zero
		distances [ start ] = 0f;
		while ( unvisited.Count != 0 )
		{
			
			// Ordering the unvisited list by distance, smallest distance at start and largest at end
			unvisited = unvisited.OrderBy ( NodeTwo => distances [ NodeTwo ] ).ToList ();
			
			// Getting the NodeTwo with smallest distance
			NodeTwo current = unvisited [ 0 ];
			
			// Remove the current NodeTwo from unvisisted list
			unvisited.Remove ( current );
			
			// When the current NodeTwo is equal to the end NodeTwo, then we can break and return the PathTwo
			if ( current == end )
			{
				
				// Construct the shortest PathTwo
				while ( previous.ContainsKey ( current ) )
				{
					
					// Insert the NodeTwo onto the final result
					PathTwo.NodeTwos.Insert ( 0, current );
					
					// Traverse from start to end
					current = previous [ current ];
				}
				
				// Insert the source onto the final result
				PathTwo.NodeTwos.Insert ( 0, current );
				break;
			}
			
			// Looping through the NodeTwo connections (neighbors) and where the connection (neighbor) is available at unvisited list
			for ( int i = 0; i < current.connections.Count; i++ )
			{
				NodeTwo neighbor = current.connections [ i ];
				
				// Getting the distance between the current NodeTwo and the connection (neighbor)
				float length = Vector3.Distance ( current.transform.position, neighbor.transform.position );
				
				// The distance from start NodeTwo to this connection (neighbor) of current NodeTwo
				float alt = distances [ current ] + length;
				
				// A shorter PathTwo to the connection (neighbor) has been found
				if ( alt < distances [ neighbor ] )
				{
					distances [ neighbor ] = alt;
					previous [ neighbor ] = current;
				}
				
			}
		}
		PathTwo.Bake ();
		return PathTwo;
	}
	
}
