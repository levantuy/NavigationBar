using System.Xml.Serialization;

namespace Guifreaks.NavigationBar
{
   public class NaviBandSetting
   {
      [XmlAttribute("name")]
      public string Name { get; set; }

      [XmlAttribute("order")]
      public int Order { get; set; }

      [XmlAttribute("visible")]
      public bool Visible { get; set; }
   }
}
