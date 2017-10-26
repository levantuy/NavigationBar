using System.Collections.Generic;
using System.Xml.Serialization;

namespace Guifreaks.NavigationBar
{
   [XmlRoot("settings")]
   public class NaviBarSettings
   {
      [XmlElement("band")]
      public List<NaviBandSetting> BandSettings { get; set; }

      [XmlElement("visibleButtons")]
      public int VisibleButtons { get; set; }

      [XmlElement("collapsed")]
      public bool Collapsed { get; set; }

      public NaviBarSettings()
      {
         BandSettings = new List<NaviBandSetting>();
      }
   }
}
