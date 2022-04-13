/*
    Name: Project 2
    Coders: Lee Hutson & James Hill
    Date: 2022-04-13
 */

namespace Project2
{
    public static class XMLExtension
    {
        public static string WriteStartDocument()
        {
            return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        }
        public static string WriteStartRootElement()
        {
            return "<root>";
        }

        public static string WriteEndRootElement()
        {
            return "</root>";
        }
        public static string StartElement()
        {
            return $"<element>";
        }

        public static string WriteEndElement()
        {
            return $"</element>";
        }

        public static string WriteAttribute(this string attribute, string value)
        {
            return $"<{attribute}>{value}</{attribute}>";
        }


    }
}
