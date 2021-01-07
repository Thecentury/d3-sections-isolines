namespace Microsoft.Research.DynamicDataDisplay.Maps.DeepZoom
{
    using System.Xml.Serialization;

    public struct uint32size
    {
        /// <summary>
        /// The width of the image.
        /// </summary>
        [XmlAttribute]
        public ulong Width { get; set; }
        /// <summary>
        /// The height of the image.
        /// </summary>
        [XmlAttribute]
        public ulong Height { get; set; }
    }
}
