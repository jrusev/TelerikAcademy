using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    // HTML table should implement ITable.
    // HTML tables have no text content and their name is "table".
    // HTML tables cannot have child elements.
    // HTML tables are HTML elements that have fixed size (rows and columns)
    // and hold rows * columns cells which are HTML elements.
    public class HTMLTable : ITable
    {
        private const string TableName = "table";
        private IElement[,] table;

        public HTMLTable(int rows, int cols)
        {
            this.Name = HTMLTable.TableName;
            this.Rows = rows;
            this.Cols = cols;
            this.table = new IElement[rows, cols];
        }

        public int Rows { get; private set; }

        public int Cols { get; private set; }

        // table[0, 0] = htmlFactory.CreateElement("b", "First Name");
        public IElement this[int row, int col]
        {
            get
            {
                return this.table[row, col];
            }
            set
            {
                this.table[row, col] = value;
            }
        }

        public string Name { get; private set; }

        public string TextContent { get; set; }

        public IEnumerable<IElement> ChildElements
        {
            get { return null; }
        }

        public void AddElement(IElement element)
        {            
        }

        //  <table>
        //      <tr>
        //          <td>(cell_0_0)</td>
        //          <td>(cell_0_1)</td>
        //          …
        //      </tr>
        //      <tr>
        //          <td>(cell_1_0)</td>
        //          <td>(cell_1_1)</td>
        //          …
        //      </tr>
        //      …
        //  </table>
        // For each row its content is rendered enclosed between the <tr> and </tr> tags.
        // For each column inside a row its element content is rendered enclosed between the <td> and </td> tags.
        public void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>", this.Name);
            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("<td>");
                    output.Append(this[row,col]);
                    output.Append("</td>");                    
                }

                output.Append("</tr>");
            }

            output.AppendFormat("</{0}>", this.Name);
        }

        // The ToString method renders the element into a string and returns it as result.
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }
    }
}