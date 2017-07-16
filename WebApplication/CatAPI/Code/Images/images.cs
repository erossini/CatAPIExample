using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace CatAPI.Code.Images
{
	public class images
	{
		// ELEMENTS
		[XmlElement("image")]
		public List<image> image { get; set; }
		
		// CONSTRUCTOR
		public images()
		{}
		
		/// <summary>
		/// Convert the structure in XML
		/// </summary>
		/// <returns>XML string</returns>
		public string ToXML()
		{
			XmlSerializer xsSubmit = new XmlSerializer(typeof(images));
			StringWriter sww = new StringWriter();
			
			XmlWriterSettings xws = new XmlWriterSettings();
			xws.Encoding = System.Text.Encoding.UTF8;
			
			XmlWriter writer = XmlWriter.Create(sww, xws);
			xsSubmit.Serialize(writer, this);
			return sww.ToString();
		}
	}
}
