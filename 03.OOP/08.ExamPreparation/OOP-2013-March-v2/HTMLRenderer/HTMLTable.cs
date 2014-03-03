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
        private int rows;
        private int cols;

        public HTMLTable(int rows, int cols)
        {
            this.Name = HTMLTable.TableName;
            this.Rows = rows;
            this.Cols = cols;
            this.table = new IElement[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ApplicationException("Cannot have negative number of rows!");
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ApplicationException("Cannot have negative number of columns!");
                }

                this.cols = value;
            }
        }

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