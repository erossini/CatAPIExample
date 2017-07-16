using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace CatAPI.Code.Categories
{
	
	public class category
	{
		// ELEMENTS
		[XmlElement("id")]
		public id id { get; set; }
		
		[XmlElement("name")]
		public name name { get; set; }
		
		// CONSTRUCTOR
		public category()
		{}
		
		/// <summary>
		/// Convert the structure in XML
		/// </summary>
		/// <returns>XML string</returns>
		public string ToXML()
		{
			XmlSerializer xsSubmit = new XmlSerializer(typeof(category));
			StringWriter sww = new StringWriter();
			
			XmlWriterSettings xws = new XmlWriterSettings();
			xws.Encoding = System.Text.Encoding.UTF8;
			
			XmlWriter writer = XmlWriter.Create(sww, xws);
			xsSubmit.Serialize(writer, this);
			return sww.ToString();
		}
	}
}
