using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLElement : IElement
    {
        private IList<IElement> childElements;

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
                // TODO: return copy
                return this.childElements;
            }
        }

        public void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        // <(name)>(text_content)(child_content)</(name)>
        // If (text_content) is missing, it is not rendered.
        // The (child_content) is rendered by rendering all child elements in the order of their addition.
        // If the element has no child elements, the (child_content) is empty.
        public void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>", this.Name);
            output.AppendFormat("{0}", this.TextContent);
            output.AppendFormat("{0}", string.Join("", this.ChildElements));
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
