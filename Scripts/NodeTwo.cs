using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The NodeTwo.
/// </summary>
public class NodeTwo : MonoBehaviour
{

    /// <summary>
    /// The connections (neighbors).
    /// </summary>
    [SerializeField]
    protected List<NodeTwo> m_Connections = new List<NodeTwo>();

    /// <summary>
    /// Gets the connections (neighbors).
    /// </summary>
    /// <value>The connections.</value>
    public virtual List<NodeTwo> connections
    {
        get
        {
            return m_Connections;
        }
    }

    public NodeTwo this[int index]
    {
        get
        {
            return m_Connections[index];
        }
    }

}
