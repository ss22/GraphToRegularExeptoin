using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DiplomProject
{
    /// <summary>
    ///  The <c>DiplomProject.Edge</c> describes the edge structure.
    /// </summary>
    public class Edge : IComparable<Edge>
    {
        
        /// <summary>
        /// The variable that stores the number of vertex from which the current edge.
        /// </summary>
        int initialVertex;

        /// <summary>
        /// Gets name of vertex from which the current edge.
        /// </summary>
        /// <value>Vertex number.</value>
        /// <remarks>InitialVertex determines the beginning of the edge.</remarks>
        [XmlElement("InitialVertex")]
        public int InitialVertex
        {
            get;
            set;
        }

        /// <summary>
        /// The variable that stores the number of vertex which falls the current edge.
        /// </summary>
        int finalVertex;

        /// <summary>
        /// Gets name of vertex which falls the current edge.
        /// </summary>
        /// <value>Vertex number.</value>
        /// <remarks>FinalVertex determines the finaly vertex of the edge.</remarks>
        [XmlElement("FinalVertex")]
        public int FinalVertex
        {
            get;
            set;
        }

        /// <summary>
        /// The variable that stores the string of regular expression.
        /// </summary>
        string regularExpression;

        /// <summary>
        /// Gets the transfer parameter (Regular expression) of current edge.
        /// </summary>
        /// <value>String of regular expression.</value>
        /// <remarks>RegularExpression determines the string of regular expression.</remarks>
        [XmlElement("regularExpression")]
        public string RegularExpression
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new empty <c>DiplomProject.Edge</c> object.
        /// </summary>
        public Edge()
        {
            initialVertex = 0;
            finalVertex = 0;
            regularExpression = "";
        }

        /// <summary>
        /// Initializes a new <c>DiplomProject.Edge</c> object with parametrs
        /// where a regular expression is generated based on the index number of edge.
        /// </summary>
        /// <param name="startVertex">Start vertex of the edge.</param>
        /// <param name="finishVertex">Finish vertex of the edge.</param>
        /// <param name="numberEdgeVertex">Index number of the edge.</param>
        public Edge(int startVertex, int finishVertex, int numberEdgeVertex)
        {
            initialVertex = startVertex;
            finalVertex = finishVertex;
            regularExpression = Convert.ToString(numberEdgeVertex, 2);
        }

        /// <summary>
        /// Initializes a new <c>DiplomProject.Edge</c> object with parametrs
        /// where a regular expression is defined. 
        /// </summary>
        /// <param name="startVertex">Start vertex of the edge.</param>
        /// <param name="finishVertex">Finish vertex of the edge.</param>
        /// <param name="regularExpressionString">String of regular expression which is transfer parameter.</param>
        public Edge(int startVertex, int finishVertex, string regularExpressionString)
        {
            initialVertex = startVertex;
            finalVertex = finishVertex;
            regularExpression = regularExpressionString;
        }

        /// <summary>
        /// Interface implementation <c>IComparable</c> with the <c>DiplomProject.Edge</c> parameter.
        /// </summary>
        /// <param name="other">The compared class object <c>DiplomProject.Edge</c>.</param>
        /// <returns>
        /// Less than zero if the parameter <c>InitialVertex</c> of the current odject less then
        /// the same parameter of the object specified by the <c>CompareTo</c> method or parameters
        /// <c>InitialVertex</c> of the compared objects are equivalent and parameter <c>FinalVertex</c>
        /// of the current object less then same parameter of compared object;
        /// Zero if this object is equal to the method parameter;
        /// Greater than zero if the parameter <c>InitialVertex</c> of the current odject Greater then
        /// the same parameter of the object specified by the <c>CompareTo</c> method or parameters
        /// <c>InitialVertex</c> of the compared objects are equivalent and parameter <c>FinalVertex</c>
        /// of the current object Greater then same parameter of compared object;
        /// </returns>
        int IComparable<Edge>.CompareTo(Edge other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;

            if (InitialVertex == other.InitialVertex)
                return FinalVertex.CompareTo(other.FinalVertex);
            else
                return InitialVertex.CompareTo(other.InitialVertex);
        }

        /// <summary>
        /// Override method implementation ToString for <c>DiplomProject.Edge</c>.
        /// </summary>
        /// <returns>String which describes the current <c>DiplomProject.Edge</c> object.</returns>
        public override string ToString()
        {
            return "|" + InitialVertex.ToString() + "| " + RegularExpression.ToString() + " |" +
                    FinalVertex.ToString() + "|";
        }

        /// <summary>
        /// Defines if the current edge is a loop.
        /// </summary>
        /// <returns>True if the current edge is loop; otherwise, false.</returns>
        public bool IsLoop()
        {
            if(InitialVertex == FinalVertex)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Integrates loop whith current edge.
        /// </summary>
        /// <param name="loop">Object of <c>DiplomProject.Edge</c> which is loop.</param>
        public void IntegrateLoopToEdge(Edge loop)
        {
            regularExpression = "(" + loop.RegularExpression + "*" + regularExpression + ")v(" + regularExpression + ")";
        }

        /// <summary>
        /// Defines if the current edge is parallel whith other edge.
        /// </summary>
        /// <param name="otherEdge">Object of <c>DiplomProject.Edge</c>.</param>
        /// <returns>True if the current edge is parallel with <c>otherEdge</c>; otherwise, false.</returns>
        public bool IsParallelEdge(Edge otherEdge)
        {
            if (initialVertex == otherEdge.InitialVertex && finalVertex == otherEdge.FinalVertex)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Combine the edges which are parallel. The regular expression of current edge =
        /// <c>(RegularExpression)v(otherEdge.RegularExpression)</c>.
        /// </summary>
        /// <param name="otherEdge"><c>DiplomProject.Edge</c> object that combines the current edge.</param>
        public string CombineWithParallelEdge(Edge otherEdge)
        {
            return "(" + regularExpression + ")v(" + otherEdge.RegularExpression + ")";
        }

        /// <summary>
        /// Defines if the current edge is relate to the specified <c>DiplomProject.Vertex</c> object.
        /// </summary>
        /// <param name="vertex"><c>DiplomProject.Vertex</c> object that is checked on relates with edge.</param>
        /// <returns>True if the current edge is relates whith <c>vertex</c>; otherwise, false.</returns>
        public bool IsRelateToVertex(Vertex vertex)
        {
            if (vertex == null) return false;

            if (initialVertex == vertex.Name || finalVertex == vertex.Name)
                return true;
            else
                return false;
        }
    }
}
