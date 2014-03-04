using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLElement : IElement
    {
        private IList<IElement> childElements;

        // Name and TextContent properties are optional and can be null
        public HTMLElement(string name = null, string content = null)
        {
            this.Name = name;
            this.TextContent = content;
            this.childElements = new List<IElement>();
        }

        public string Name { get; private set; }

        public string TextContent { get; set; }

        public IEnumerable<IElement> ChildElements
        {
            get
            {
                // return copy
                return new List<IElement>(this.childElements);
            }
        }

        public void AddElement(IElement element)
        {
            if (element == null)
            {
                throw new ApplicationException("Cannot add a null element!");
            }

            this.childElements.Add(element);
        }

        // <(name)>(text_content)(child_content)</(name)>
        // If (text_content) is missing, it is not rendered.
        // The (child_content) is rendered by rendering all child elements in the order of their addition.
        // If the element has no child elements, the (child_content) is empty.
        // When a TextContent is rendered, the HTML special characters <, > and & are escaped as &lt;, &gt;, &amp; 
        // When elements are rendered, no spacing or new lines is put between them.
        public void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.AppendFormat("<{0}>", this.Name);
            }

            if (this.TextContent != null)
            {
                string escapedContent = this.TextContent.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
                output.AppendFormat("{0}", escapedContent);
            }

            output.AppendFormat("{0}", string.Join(string.Empty, this.ChildElements));

            if (this.Name != null)
            {
                output.AppendFormat("</{0}>", this.Name);     
            }                   
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
