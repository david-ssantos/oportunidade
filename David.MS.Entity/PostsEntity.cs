﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace David.MS.Entity
{
	[XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
	public class Link
	{
		[XmlAttribute(AttributeName = "href")]
		public string Href { get; set; }
		[XmlAttribute(AttributeName = "rel")]
		public string Rel { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName = "guid")]
	public class Guid
	{
		[XmlAttribute(AttributeName = "isPermaLink")]
		public string IsPermaLink { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "item")]
	public class Item
	{
		[XmlElement(ElementName = "title")]
		public string Title { get; set; }
		[XmlElement(ElementName = "link")]
		public string Link2 { get; set; }
		[XmlElement(ElementName = "comments")]
		public List<string> Comments { get; set; }
		[XmlElement(ElementName = "pubDate")]
		public string PubDate { get; set; }
		[XmlElement(ElementName = "creator", Namespace = "http://purl.org/dc/elements/1.1/")]
		public string Creator { get; set; }
		[XmlElement(ElementName = "category")]
		public List<string> Category { get; set; }
		[XmlElement(ElementName = "guid")]
		public Guid Guid { get; set; }
		[XmlElement(ElementName = "description")]
		public string Description { get; set; }
		[XmlElement(ElementName = "encoded", Namespace = "http://purl.org/rss/1.0/modules/content/")]
		public string Encoded { get; set; }
		[XmlElement(ElementName = "commentRss", Namespace = "http://wellformedweb.org/CommentAPI/")]
		public string CommentRss { get; set; }
	}

	[XmlRoot(ElementName = "channel")]
	public class Channel
	{
		[XmlElement(ElementName = "title")]
		public List<string> Title { get; set; }
		[XmlElement(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
		public List<Link> Link { get; set; }
		[XmlElement(ElementName = "link")]
		public List<string> Link2 { get; set; }
		[XmlElement(ElementName = "description")]
		public List<string> Description { get; set; }
		[XmlElement(ElementName = "lastBuildDate")]
		public List<string> LastBuildDate { get; set; }
		[XmlElement(ElementName = "language")]
		public List<string> Language { get; set; }
		[XmlElement(ElementName = "updatePeriod", Namespace = "http://purl.org/rss/1.0/modules/syndication/")]
		public List<string> UpdatePeriod { get; set; }
		[XmlElement(ElementName = "updateFrequency", Namespace = "http://purl.org/rss/1.0/modules/syndication/")]
		public List<string> UpdateFrequency { get; set; }
		[XmlElement(ElementName = "generator")]
		public List<string> Generator { get; set; }
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; }
	}

	[XmlRoot(ElementName = "rss")]
	public class Rss
	{
		[XmlElement(ElementName = "channel")]
		public Channel Channel { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName = "content", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Content { get; set; }
		[XmlAttribute(AttributeName = "wfw", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Wfw { get; set; }
		[XmlAttribute(AttributeName = "dc", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Dc { get; set; }
		[XmlAttribute(AttributeName = "atom", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Atom { get; set; }
		[XmlAttribute(AttributeName = "sy", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Sy { get; set; }
		[XmlAttribute(AttributeName = "slash", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Slash { get; set; }
	}

}
