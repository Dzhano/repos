using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Template 
        {
            get
            {
                StringBuilder text = new StringBuilder();
                text.AppendLine("<log>");
                text.AppendLine("   <date>{0}</date>");
                text.AppendLine("   <level>{1}</level>");
                text.AppendLine("   <message>{2}</message>");
                text.AppendLine("</log>");

                return text.ToString().TrimEnd();
            } 
        }
    }
}
