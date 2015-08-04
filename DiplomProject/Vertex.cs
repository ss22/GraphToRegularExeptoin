using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DiplomProject
{
    /// <summary>
    /// The <c>DiplomProject.Vertex</c> describes the vertex structure.
    /// </summary>
    public class Vertex : IComparable<Vertex>
    {
        /// <summary>
        /// The variable that stores the name of current vertex.
        /// </summary>
        int name;

        /// <summary>
        /// Get the name of current vertex.
        /// </summary>
        /// <value>Vertex name.</value>
        /// <remarks>Name determines the vertex.</remarks>
        [XmlElement("Name")]
        public int Name
        {
            get { return name; }
            set { name = value; }
        }


        /// <summary>
        /// The variable that stores the number of edges for current vertex.
        /// </summary>
        int edgesNumber;

        /// <summary>
        /// Get the number of edges for current vertex.
        /// </summary>
        /// <value>Vertex number.</value>
        /// <remarks><c>EdgeNumber</c> determines the number of edges of this vertex.</remarks>
        [XmlElement("EdgesNumber")]
        public int EdgesNumber
        {
            get { return edgesNumber; }
            set { edgesNumber = value; } 
        }

        /// <summary>
        /// Interface implementation <c>IComparable</c> with the <c>DiplomProject.Vertex</c> parameter.
        /// </summary>
        /// <param name="other">The compared class object <c>DiplomProject.Vertex</c>.</param>
        /// <returns>
        /// Less than zero if this object is less than the object specified by the <c>CompareTo</c> method;
        /// Zero if this object is equal to the method parameter;
        /// Greater than zero if this object is greater than the method parameter.
        /// </returns>
        int IComparable<Vertex>.CompareTo(Vertex other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;

            // The vertices comparison depends on the of number of edges vertex.
            return edgesNumber.CompareTo(other.edgesNumber);
        }

        /// <summary>
        /// Override method implementation ToString for <c>DiplomProject.Vertex</c>.
        /// </summary>
        /// <returns>String which describes the current <c>DiplomProject.Vertex</c> object.</returns>
        public override string ToString()
        {
            return "Vertex: " + name.ToString() + "; Edges = " + edgesNumber.ToString();
        }

        /// <summary>
        /// Initializes a new empty <c>DiplomProject.Vertex</c> object.
        /// </summary>
        public Vertex()
        {
            name = 0;
            edgesNumber = 0;
        }

        /// <summary>
        /// Initializes a new <c>DiplomProject.Vertex</c> object with parametrs.
        /// </summary>
        /// <param name="name">Vertex name.</param>
        /// <param name="edgeNumber">Sum of incoming and outgoing edges.</param>
        public Vertex(int name, int edgeNumber)
        {
            Name = name;
            EdgesNumber = edgeNumber;
        }

        /// <summary>
        /// Increase number of edges for current vertex on 1.
        /// </summary>
        public void IncreaseNumberOfEdges()
        {
            edgesNumber++;
        }

        /// <summary>
        /// Increase number of edges for current vertex on value.
        /// </summary>
        /// <param name="value">The number to which you want increase
        /// number of edges for current vertex.</param>
        public void IncreaseNumberOfEdges(int value)
        {
            edgesNumber += value;
        }

        /// <summary>
        /// Decrease number of edges for current vertex on 1.
        /// </summary>
        public void DecreaseNumberOfEdges()
        {
            edgesNumber--;
        }

        /// <summary>
        /// Decrease number of edges for current vertex on value.
        /// </summary>
        /// <param name="value">The number to which you want decrease
        /// number of edges for current vertex.</param>
        public void DecreaseNumberOfEdges(int value)
        {
            edgesNumber = edgesNumber - value;
        }
    }
}
