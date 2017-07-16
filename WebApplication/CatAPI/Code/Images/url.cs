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
	public class url
	{
		// ELEMENTS
		[XmlText]
		public string Value { get; set; }
		
		// CONSTRUCTOR
		public url()
		{}
		
		/// <summary>
		/// Convert the structure in XML
		/// </summary>
		/// <returns>XML string</returns>
		public string ToXML()
		{
			XmlSerializer xsSubmit = new XmlSerializer(typeof(url));
			StringWriter sww = new StringWriter();
			
			XmlWriterSettings xws = new XmlWriterSettings();
			xws.Encoding = System.Text.Encoding.UTF8;
			
			XmlWriter writer = XmlWriter.Create(sww, xws);
			xsSubmit.Serialize(writer, this);
			return sww.ToString();
		}
	}
}
