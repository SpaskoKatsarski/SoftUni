﻿namespace Boardgames.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Boardgame")]
    public class ExportBoardgameDto
    {
        [XmlElement("BoardgameName")]
        public string Name { get; set; } = null!;

        [XmlElement("BoardgameYearPublished")]
        public int YearPublished { get; set; }
    }
}
