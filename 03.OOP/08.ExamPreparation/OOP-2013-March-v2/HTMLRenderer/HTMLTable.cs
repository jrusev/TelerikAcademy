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

        // <table><tr><td>(cell_0_0)</td><td>(cell_0_1)</td>…</tr><tr><td>(cell_1_0)</td><td>(cell_1_1)</td>…</tr>…</table>
        public void Render(StringBuilder output)
        {
            throw new NotImplementedException();
        }
    }
}