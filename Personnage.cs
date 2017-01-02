using System.Xml.Serialization;
public class Personnage {
  [XmlAttribute("name")] public string Name;
  [XmlAttribute("hp")] public int Hp;
  [XmlAttribute("mp")] public int Mp;
  public string Classe;
}