//
// ImageListStreamerTest.cs: Test cases for ImageListStreamer.
//
// Author:
//	Gert Driesen <drieseng@users.sourceforge.net>
//
// (C) 2008 Gert Driesen
//

using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

using NUnit.Framework;

namespace MonoTests.System.Windows.Forms
{
	[TestFixture]
	public class ImageListStreamerTest : TestHelper
	{
		[Test]
		[Category ("NotWorking")]
		public void Serialize ()
		{
			Assembly a = typeof (ImageListStreamerTest).Assembly;

			ImageList imgList = new ImageList ();
			imgList.Images.Add (Image.FromStream (a.GetManifestResourceStream ("32x32.ico")));
			imgList.Images.Add (Image.FromFile ("M.gif"));

			MemoryStream ms = new MemoryStream ();

			BinaryFormatter bf = new BinaryFormatter ();
			bf.Serialize (ms, imgList.ImageStream);

			ms.Position = 0;

			byte [] ser = new byte [ms.Length];
			ms.Read (ser, 0, ser.Length);

			Assert.AreEqual (_serialized, ser);
		}

		[Test]
		[Category ("NotWorking")]
		public void Deserialize ()
		{
			ImageList imgList = new ImageList ();

			MemoryStream ms = new MemoryStream ();
			ms.Write (_serialized, 0, _serialized.Length);
			ms.Position = 0;

			BinaryFormatter bf = new BinaryFormatter ();
			imgList.ImageStream = (ImageListStreamer) bf.Deserialize (ms);
			Assert.AreEqual (2, imgList.Images.Count, "#1");
			Assert.AreEqual (ColorDepth.Depth8Bit, imgList.ColorDepth, "#2");
			Assert.AreEqual (new Size (16, 16), imgList.ImageSize, "#3");
		}

		static byte [] _serialized = {
#if NET_2_0
			0x00, 0x01, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x01,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C, 0x02, 0x00,
			0x00, 0x00, 0x57, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E,
			0x57, 0x69, 0x6E, 0x64, 0x6F, 0x77, 0x73, 0x2E, 0x46, 0x6F,
			0x72, 0x6D, 0x73, 0x2C, 0x20, 0x56, 0x65, 0x72, 0x73, 0x69,
			0x6F, 0x6E, 0x3D, 0x32, 0x2E, 0x30, 0x2E, 0x30, 0x2E, 0x30,
			0x2C, 0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D,
			0x6E, 0x65, 0x75, 0x74, 0x72, 0x61, 0x6C, 0x2C, 0x20, 0x50,
			0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F,
			0x6B, 0x65, 0x6E, 0x3D, 0x62, 0x37, 0x37, 0x61, 0x35, 0x63,
			0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30, 0x38, 0x39,
			0x05, 0x01, 0x00, 0x00, 0x00, 0x26, 0x53, 0x79, 0x73, 0x74,
			0x65, 0x6D, 0x2E, 0x57, 0x69, 0x6E, 0x64, 0x6F, 0x77, 0x73,
			0x2E, 0x46, 0x6F, 0x72, 0x6D, 0x73, 0x2E, 0x49, 0x6D, 0x61,
			0x67, 0x65, 0x4C, 0x69, 0x73, 0x74, 0x53, 0x74, 0x72, 0x65,
			0x61, 0x6D, 0x65, 0x72, 0x01, 0x00, 0x00, 0x00, 0x04, 0x44,
			0x61, 0x74, 0x61, 0x07, 0x02, 0x02, 0x00, 0x00, 0x00, 0x09,
			0x03, 0x00, 0x00, 0x00, 0x0F, 0x03, 0x00, 0x00, 0x00, 0x0A,
			0x09, 0x00, 0x00, 0x02, 0x4D, 0x53, 0x46, 0x74, 0x01, 0x49,
			0x01, 0x4C, 0x02, 0x01, 0x01, 0x02, 0x01, 0x00, 0x01, 0x05,
			0x01, 0x00, 0x01, 0x04, 0x01, 0x00, 0x01, 0x10, 0x01, 0x00,
			0x01, 0x10, 0x01, 0x00, 0x04, 0xFF, 0x01, 0x09, 0x01, 0x00,
			0x08, 0xFF, 0x01, 0x42, 0x01, 0x4D, 0x01, 0x36, 0x01, 0x04,
			0x06, 0x00, 0x01, 0x36, 0x01, 0x04, 0x02, 0x00, 0x01, 0x28,
			0x03, 0x00, 0x01, 0x40, 0x03, 0x00, 0x01, 0x20, 0x03, 0x00,
			0x01, 0x01, 0x01, 0x00, 0x01, 0x08, 0x06, 0x00, 0x01, 0x08,
			0x18, 0x00, 0x01, 0x80, 0x02, 0x00, 0x01, 0x80, 0x03, 0x00,
			0x02, 0x80, 0x01, 0x00, 0x01, 0x80, 0x03, 0x00, 0x01, 0x80,
			0x01, 0x00, 0x01, 0x80, 0x01, 0x00, 0x02, 0x80, 0x02, 0x00,
			0x03, 0xC0, 0x01, 0x00, 0x01, 0xC0, 0x01, 0xDC, 0x01, 0xC0,
			0x01, 0x00, 0x01, 0xF0, 0x01, 0xCA, 0x01, 0xA6, 0x01, 0x00,
			0x01, 0x33, 0x05, 0x00, 0x01, 0x33, 0x01, 0x00, 0x01, 0x33,
			0x01, 0x00, 0x01, 0x33, 0x01, 0x00, 0x02, 0x33, 0x02, 0x00,
			0x03, 0x16, 0x01, 0x00, 0x03, 0x1C, 0x01, 0x00, 0x03, 0x22,
			0x01, 0x00, 0x03, 0x29, 0x01, 0x00, 0x03, 0x55, 0x01, 0x00,
			0x03, 0x4D, 0x01, 0x00, 0x03, 0x42, 0x01, 0x00, 0x03, 0x39,
			0x01, 0x00, 0x01, 0x80, 0x01, 0x7C, 0x01, 0xFF, 0x01, 0x00,
			0x02, 0x50, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x93, 0x01, 0x00,
			0x01, 0xD6, 0x01, 0x00, 0x01, 0xFF, 0x01, 0xEC, 0x01, 0xCC,
			0x01, 0x00, 0x01, 0xC6, 0x01, 0xD6, 0x01, 0xEF, 0x01, 0x00,
			0x01, 0xD6, 0x02, 0xE7, 0x01, 0x00, 0x01, 0x90, 0x01, 0xA9,
			0x01, 0xAD, 0x02, 0x00, 0x01, 0xFF, 0x01, 0x33, 0x03, 0x00,
			0x01, 0x66, 0x03, 0x00, 0x01, 0x99, 0x03, 0x00, 0x01, 0xCC,
			0x02, 0x00, 0x01, 0x33, 0x03, 0x00, 0x02, 0x33, 0x02, 0x00,
			0x01, 0x33, 0x01, 0x66, 0x02, 0x00, 0x01, 0x33, 0x01, 0x99,
			0x02, 0x00, 0x01, 0x33, 0x01, 0xCC, 0x02, 0x00, 0x01, 0x33,
			0x01, 0xFF, 0x02, 0x00, 0x01, 0x66, 0x03, 0x00, 0x01, 0x66,
			0x01, 0x33, 0x02, 0x00, 0x02, 0x66, 0x02, 0x00, 0x01, 0x66,
			0x01, 0x99, 0x02, 0x00, 0x01, 0x66, 0x01, 0xCC, 0x02, 0x00,
			0x01, 0x66, 0x01, 0xFF, 0x02, 0x00, 0x01, 0x99, 0x03, 0x00,
			0x01, 0x99, 0x01, 0x33, 0x02, 0x00, 0x01, 0x99, 0x01, 0x66,
			0x02, 0x00, 0x02, 0x99, 0x02, 0x00, 0x01, 0x99, 0x01, 0xCC,
			0x02, 0x00, 0x01, 0x99, 0x01, 0xFF, 0x02, 0x00, 0x01, 0xCC,
			0x03, 0x00, 0x01, 0xCC, 0x01, 0x33, 0x02, 0x00, 0x01, 0xCC,
			0x01, 0x66, 0x02, 0x00, 0x01, 0xCC, 0x01, 0x99, 0x02, 0x00,
			0x02, 0xCC, 0x02, 0x00, 0x01, 0xCC, 0x01, 0xFF, 0x02, 0x00,
			0x01, 0xFF, 0x01, 0x66, 0x02, 0x00, 0x01, 0xFF, 0x01, 0x99,
			0x02, 0x00, 0x01, 0xFF, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x33,
			0x01, 0xFF, 0x02, 0x00, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x33,
			0x01, 0x00, 0x01, 0x33, 0x01, 0x00, 0x01, 0x66, 0x01, 0x00,
			0x01, 0x33, 0x01, 0x00, 0x01, 0x99, 0x01, 0x00, 0x01, 0x33,
			0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x33, 0x01, 0x00,
			0x01, 0xFF, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x33, 0x02, 0x00,
			0x03, 0x33, 0x01, 0x00, 0x02, 0x33, 0x01, 0x66, 0x01, 0x00,
			0x02, 0x33, 0x01, 0x99, 0x01, 0x00, 0x02, 0x33, 0x01, 0xCC,
			0x01, 0x00, 0x02, 0x33, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x33,
			0x01, 0x66, 0x02, 0x00, 0x01, 0x33, 0x01, 0x66, 0x01, 0x33,
			0x01, 0x00, 0x01, 0x33, 0x02, 0x66, 0x01, 0x00, 0x01, 0x33,
			0x01, 0x66, 0x01, 0x99, 0x01, 0x00, 0x01, 0x33, 0x01, 0x66,
			0x01, 0xCC, 0x01, 0x00, 0x01, 0x33, 0x01, 0x66, 0x01, 0xFF,
			0x01, 0x00, 0x01, 0x33, 0x01, 0x99, 0x02, 0x00, 0x01, 0x33,
			0x01, 0x99, 0x01, 0x33, 0x01, 0x00, 0x01, 0x33, 0x01, 0x99,
			0x01, 0x66, 0x01, 0x00, 0x01, 0x33, 0x02, 0x99, 0x01, 0x00,
			0x01, 0x33, 0x01, 0x99, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x33,
			0x01, 0x99, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x33, 0x01, 0xCC,
			0x02, 0x00, 0x01, 0x33, 0x01, 0xCC, 0x01, 0x33, 0x01, 0x00,
			0x01, 0x33, 0x01, 0xCC, 0x01, 0x66, 0x01, 0x00, 0x01, 0x33,
			0x01, 0xCC, 0x01, 0x99, 0x01, 0x00, 0x01, 0x33, 0x02, 0xCC,
			0x01, 0x00, 0x01, 0x33, 0x01, 0xCC, 0x01, 0xFF, 0x01, 0x00,
			0x01, 0x33, 0x01, 0xFF, 0x01, 0x33, 0x01, 0x00, 0x01, 0x33,
			0x01, 0xFF, 0x01, 0x66, 0x01, 0x00, 0x01, 0x33, 0x01, 0xFF,
			0x01, 0x99, 0x01, 0x00, 0x01, 0x33, 0x01, 0xFF, 0x01, 0xCC,
			0x01, 0x00, 0x01, 0x33, 0x02, 0xFF, 0x01, 0x00, 0x01, 0x66,
			0x03, 0x00, 0x01, 0x66, 0x01, 0x00, 0x01, 0x33, 0x01, 0x00,
			0x01, 0x66, 0x01, 0x00, 0x01, 0x66, 0x01, 0x00, 0x01, 0x66,
			0x01, 0x00, 0x01, 0x99, 0x01, 0x00, 0x01, 0x66, 0x01, 0x00,
			0x01, 0xCC, 0x01, 0x00, 0x01, 0x66, 0x01, 0x00, 0x01, 0xFF,
			0x01, 0x00, 0x01, 0x66, 0x01, 0x33, 0x02, 0x00, 0x01, 0x66,
			0x02, 0x33, 0x01, 0x00, 0x01, 0x66, 0x01, 0x33, 0x01, 0x66,
			0x01, 0x00, 0x01, 0x66, 0x01, 0x33, 0x01, 0x99, 0x01, 0x00,
			0x01, 0x66, 0x01, 0x33, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x66,
			0x01, 0x33, 0x01, 0xFF, 0x01, 0x00, 0x02, 0x66, 0x02, 0x00,
			0x02, 0x66, 0x01, 0x33, 0x01, 0x00, 0x03, 0x66, 0x01, 0x00,
			0x02, 0x66, 0x01, 0x99, 0x01, 0x00, 0x02, 0x66, 0x01, 0xCC,
			0x01, 0x00, 0x01, 0x66, 0x01, 0x99, 0x02, 0x00, 0x01, 0x66,
			0x01, 0x99, 0x01, 0x33, 0x01, 0x00, 0x01, 0x66, 0x01, 0x99,
			0x01, 0x66, 0x01, 0x00, 0x01, 0x66, 0x02, 0x99, 0x01, 0x00,
			0x01, 0x66, 0x01, 0x99, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x66,
			0x01, 0x99, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x66, 0x01, 0xCC,
			0x02, 0x00, 0x01, 0x66, 0x01, 0xCC, 0x01, 0x33, 0x01, 0x00,
			0x01, 0x66, 0x01, 0xCC, 0x01, 0x99, 0x01, 0x00, 0x01, 0x66,
			0x02, 0xCC, 0x01, 0x00, 0x01, 0x66, 0x01, 0xCC, 0x01, 0xFF,
			0x01, 0x00, 0x01, 0x66, 0x01, 0xFF, 0x02, 0x00, 0x01, 0x66,
			0x01, 0xFF, 0x01, 0x33, 0x01, 0x00, 0x01, 0x66, 0x01, 0xFF,
			0x01, 0x99, 0x01, 0x00, 0x01, 0x66, 0x01, 0xFF, 0x01, 0xCC,
			0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x00,
			0x01, 0xFF, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x02, 0x99,
			0x02, 0x00, 0x01, 0x99, 0x01, 0x33, 0x01, 0x99, 0x01, 0x00,
			0x01, 0x99, 0x01, 0x00, 0x01, 0x99, 0x01, 0x00, 0x01, 0x99,
			0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x99, 0x03, 0x00,
			0x01, 0x99, 0x02, 0x33, 0x01, 0x00, 0x01, 0x99, 0x01, 0x00,
			0x01, 0x66, 0x01, 0x00, 0x01, 0x99, 0x01, 0x33, 0x01, 0xCC,
			0x01, 0x00, 0x01, 0x99, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x00,
			0x01, 0x99, 0x01, 0x66, 0x02, 0x00, 0x01, 0x99, 0x01, 0x66,
			0x01, 0x33, 0x01, 0x00, 0x01, 0x99, 0x01, 0x33, 0x01, 0x66,
			0x01, 0x00, 0x01, 0x99, 0x01, 0x66, 0x01, 0x99, 0x01, 0x00,
			0x01, 0x99, 0x01, 0x66, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x99,
			0x01, 0x33, 0x01, 0xFF, 0x01, 0x00, 0x02, 0x99, 0x01, 0x33,
			0x01, 0x00, 0x02, 0x99, 0x01, 0x66, 0x01, 0x00, 0x03, 0x99,
			0x01, 0x00, 0x02, 0x99, 0x01, 0xCC, 0x01, 0x00, 0x02, 0x99,
			0x01, 0xFF, 0x01, 0x00, 0x01, 0x99, 0x01, 0xCC, 0x02, 0x00,
			0x01, 0x99, 0x01, 0xCC, 0x01, 0x33, 0x01, 0x00, 0x01, 0x66,
			0x01, 0xCC, 0x01, 0x66, 0x01, 0x00, 0x01, 0x99, 0x01, 0xCC,
			0x01, 0x99, 0x01, 0x00, 0x01, 0x99, 0x02, 0xCC, 0x01, 0x00,
			0x01, 0x99, 0x01, 0xCC, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x99,
			0x01, 0xFF, 0x02, 0x00, 0x01, 0x99, 0x01, 0xFF, 0x01, 0x33,
			0x01, 0x00, 0x01, 0x99, 0x01, 0xCC, 0x01, 0x66, 0x01, 0x00,
			0x01, 0x99, 0x01, 0xFF, 0x01, 0x99, 0x01, 0x00, 0x01, 0x99,
			0x01, 0xFF, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x99, 0x02, 0xFF,
			0x01, 0x00, 0x01, 0xCC, 0x03, 0x00, 0x01, 0x99, 0x01, 0x00,
			0x01, 0x33, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x66,
			0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x99, 0x01, 0x00,
			0x01, 0xCC, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x99,
			0x01, 0x33, 0x02, 0x00, 0x01, 0xCC, 0x02, 0x33, 0x01, 0x00,
			0x01, 0xCC, 0x01, 0x33, 0x01, 0x66, 0x01, 0x00, 0x01, 0xCC,
			0x01, 0x33, 0x01, 0x99, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x33,
			0x01, 0xCC, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x33, 0x01, 0xFF,
			0x01, 0x00, 0x01, 0xCC, 0x01, 0x66, 0x02, 0x00, 0x01, 0xCC,
			0x01, 0x66, 0x01, 0x33, 0x01, 0x00, 0x01, 0x99, 0x02, 0x66,
			0x01, 0x00, 0x01, 0xCC, 0x01, 0x66, 0x01, 0x99, 0x01, 0x00,
			0x01, 0xCC, 0x01, 0x66, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x99,
			0x01, 0x66, 0x01, 0xFF, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x99,
			0x02, 0x00, 0x01, 0xCC, 0x01, 0x99, 0x01, 0x33, 0x01, 0x00,
			0x01, 0xCC, 0x01, 0x99, 0x01, 0x66, 0x01, 0x00, 0x01, 0xCC,
			0x02, 0x99, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x99, 0x01, 0xCC,
			0x01, 0x00, 0x01, 0xCC, 0x01, 0x99, 0x01, 0xFF, 0x01, 0x00,
			0x02, 0xCC, 0x02, 0x00, 0x02, 0xCC, 0x01, 0x33, 0x01, 0x00,
			0x02, 0xCC, 0x01, 0x66, 0x01, 0x00, 0x02, 0xCC, 0x01, 0x99,
			0x01, 0x00, 0x03, 0xCC, 0x01, 0x00, 0x02, 0xCC, 0x01, 0xFF,
			0x01, 0x00, 0x01, 0xCC, 0x01, 0xFF, 0x02, 0x00, 0x01, 0xCC,
			0x01, 0xFF, 0x01, 0x33, 0x01, 0x00, 0x01, 0x99, 0x01, 0xFF,
			0x01, 0x66, 0x01, 0x00, 0x01, 0xCC, 0x01, 0xFF, 0x01, 0x99,
			0x01, 0x00, 0x01, 0xCC, 0x01, 0xFF, 0x01, 0xCC, 0x01, 0x00,
			0x01, 0xCC, 0x02, 0xFF, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x00,
			0x01, 0x33, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x66,
			0x01, 0x00, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x99, 0x01, 0x00,
			0x01, 0xCC, 0x01, 0x33, 0x02, 0x00, 0x01, 0xFF, 0x02, 0x33,
			0x01, 0x00, 0x01, 0xFF, 0x01, 0x33, 0x01, 0x66, 0x01, 0x00,
			0x01, 0xFF, 0x01, 0x33, 0x01, 0x99, 0x01, 0x00, 0x01, 0xFF,
			0x01, 0x33, 0x01, 0xCC, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x33,
			0x01, 0xFF, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x66, 0x02, 0x00,
			0x01, 0xFF, 0x01, 0x66, 0x01, 0x33, 0x01, 0x00, 0x01, 0xCC,
			0x02, 0x66, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x66, 0x01, 0x99,
			0x01, 0x00, 0x01, 0xFF, 0x01, 0x66, 0x01, 0xCC, 0x01, 0x00,
			0x01, 0xCC, 0x01, 0x66, 0x01, 0xFF, 0x01, 0x00, 0x01, 0xFF,
			0x01, 0x99, 0x02, 0x00, 0x01, 0xFF, 0x01, 0x99, 0x01, 0x33,
			0x01, 0x00, 0x01, 0xFF, 0x01, 0x99, 0x01, 0x66, 0x01, 0x00,
			0x01, 0xFF, 0x02, 0x99, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x99,
			0x01, 0xCC, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x99, 0x01, 0xFF,
			0x01, 0x00, 0x01, 0xFF, 0x01, 0xCC, 0x02, 0x00, 0x01, 0xFF,
			0x01, 0xCC, 0x01, 0x33, 0x01, 0x00, 0x01, 0xFF, 0x01, 0xCC,
			0x01, 0x66, 0x01, 0x00, 0x01, 0xFF, 0x01, 0xCC, 0x01, 0x99,
			0x01, 0x00, 0x01, 0xFF, 0x02, 0xCC, 0x01, 0x00, 0x01, 0xFF,
			0x01, 0xCC, 0x01, 0xFF, 0x01, 0x00, 0x02, 0xFF, 0x01, 0x33,
			0x01, 0x00, 0x01, 0xCC, 0x01, 0xFF, 0x01, 0x66, 0x01, 0x00,
			0x02, 0xFF, 0x01, 0x99, 0x01, 0x00, 0x02, 0xFF, 0x01, 0xCC,
			0x01, 0x00, 0x02, 0x66, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x66,
			0x01, 0xFF, 0x01, 0x66, 0x01, 0x00, 0x01, 0x66, 0x02, 0xFF,
			0x01, 0x00, 0x01, 0xFF, 0x02, 0x66, 0x01, 0x00, 0x01, 0xFF,
			0x01, 0x66, 0x01, 0xFF, 0x01, 0x00, 0x02, 0xFF, 0x01, 0x66,
			0x01, 0x00, 0x01, 0x21, 0x01, 0x00, 0x01, 0xA5, 0x01, 0x00,
			0x03, 0x5F, 0x01, 0x00, 0x03, 0x77, 0x01, 0x00, 0x03, 0x86,
			0x01, 0x00, 0x03, 0x96, 0x01, 0x00, 0x03, 0xCB, 0x01, 0x00,
			0x03, 0xB2, 0x01, 0x00, 0x03, 0xD7, 0x01, 0x00, 0x03, 0xDD,
			0x01, 0x00, 0x03, 0xE3, 0x01, 0x00, 0x03, 0xEA, 0x01, 0x00,
			0x03, 0xF1, 0x01, 0x00, 0x03, 0xF8, 0x01, 0x00, 0x01, 0xF0,
			0x01, 0xFB, 0x01, 0xFF, 0x01, 0x00, 0x01, 0xA4, 0x02, 0xA0,
			0x01, 0x00, 0x03, 0x80, 0x03, 0x00, 0x01, 0xFF, 0x02, 0x00,
			0x01, 0xFF, 0x03, 0x00, 0x02, 0xFF, 0x01, 0x00, 0x01, 0xFF,
			0x03, 0x00, 0x01, 0xFF, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x00,
			0x02, 0xFF, 0x02, 0x00, 0x03, 0xFF, 0xFF, 0x00, 0xFF, 0x00,
			0xFF, 0x00, 0xFF, 0x00, 0x05, 0x00, 0x10, 0x05, 0x01, 0x00,
			0x04, 0xF8, 0x01, 0xAE, 0x01, 0xF8, 0x01, 0xAE, 0x04, 0x6D,
			0x04, 0xEA, 0x20, 0x00, 0x01, 0x05, 0x0E, 0xFF, 0x01, 0x05,
			0x01, 0x00, 0x01, 0xEA, 0x02, 0xEB, 0x01, 0xEF, 0x01, 0xF8,
			0x01, 0xED, 0x01, 0xF8, 0x01, 0xED, 0x01, 0x6D, 0x02, 0xEC,
			0x01, 0x13, 0x01, 0xED, 0x01, 0x12, 0x01, 0x15, 0x20, 0x00,
			0x01, 0x05, 0x08, 0xFF, 0x04, 0x05, 0x02, 0xFF, 0x01, 0x05,
			0x01, 0x00, 0x01, 0x59, 0x01, 0xF7, 0x01, 0xEB, 0x02, 0xED,
			0x01, 0x07, 0x01, 0xEF, 0x01, 0x92, 0x01, 0xF8, 0x01, 0x07,
			0x01, 0xED, 0x01, 0xEA, 0x01, 0xF8, 0x01, 0x13, 0x01, 0x59,
			0x20, 0x00, 0x01, 0x05, 0x07, 0xFF, 0x05, 0x05, 0x02, 0xFF,
			0x01, 0x05, 0x01, 0x00, 0x01, 0x43, 0x06, 0x91, 0x03, 0xAE,
			0x02, 0x6D, 0x02, 0xEA, 0x01, 0x43, 0x20, 0x00, 0x01, 0x05,
			0x06, 0xFF, 0x06, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01, 0x00,
			0x01, 0xAE, 0x01, 0xEB, 0x05, 0xAE, 0x02, 0x6C, 0x03, 0x66,
			0x02, 0x15, 0x01, 0x43, 0x20, 0x00, 0x01, 0x05, 0x05, 0xFF,
			0x07, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01, 0x00, 0x01, 0xAE,
			0x02, 0x6D, 0x03, 0xAE, 0x01, 0x8B, 0x01, 0x6C, 0x03, 0x66,
			0x01, 0x15, 0x01, 0x43, 0x02, 0x11, 0x20, 0x00, 0x01, 0x05,
			0x04, 0xFF, 0x08, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01, 0x00,
			0x01, 0xAE, 0x02, 0xF1, 0x01, 0x14, 0x05, 0xAE, 0x01, 0x66,
			0x01, 0xEA, 0x01, 0x15, 0x01, 0x14, 0x01, 0x15, 0x01, 0x11,
			0x20, 0x00, 0x01, 0x05, 0x03, 0xFF, 0x05, 0x05, 0x01, 0xFF,
			0x03, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01, 0x00, 0x01, 0xAE,
			0x01, 0xFF, 0x01, 0xAE, 0x01, 0x12, 0x01, 0xF7, 0x01, 0xEF,
			0x01, 0x07, 0x01, 0x6D, 0x01, 0xF7, 0x01, 0x6D, 0x01, 0xEA,
			0x01, 0xEB, 0x01, 0xEF, 0x01, 0x12, 0x01, 0x11, 0x20, 0x00,
			0x01, 0x05, 0x02, 0xFF, 0x05, 0x05, 0x02, 0xFF, 0x03, 0x05,
			0x02, 0xFF, 0x01, 0x05, 0x01, 0x00, 0x02, 0xAE, 0x01, 0x92,
			0x01, 0x12, 0x01, 0x91, 0x02, 0xAE, 0x01, 0x8B, 0x01, 0x6C,
			0x03, 0x66, 0x01, 0x15, 0x01, 0x43, 0x01, 0x11, 0x20, 0x00,
			0x01, 0x05, 0x01, 0xFF, 0x05, 0x05, 0x03, 0xFF, 0x03, 0x05,
			0x02, 0xFF, 0x01, 0x05, 0x01, 0x00, 0x01, 0xAE, 0x02, 0x91,
			0x01, 0x12, 0x01, 0xEB, 0x02, 0xEF, 0x01, 0xED, 0x01, 0x43,
			0x01, 0x66, 0x01, 0x43, 0x01, 0x07, 0x01, 0x13, 0x01, 0xF7,
			0x01, 0x11, 0x20, 0x00, 0x01, 0x05, 0x01, 0xFF, 0x04, 0x05,
			0x04, 0xFF, 0x03, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01, 0x00,
			0x01, 0x6D, 0x02, 0xEC, 0x01, 0x12, 0x01, 0xF7, 0x02, 0xFF,
			0x02, 0xED, 0x01, 0x66, 0x03, 0x43, 0x01, 0x14, 0x01, 0x11,
			0x20, 0x00, 0x01, 0x05, 0x01, 0xFF, 0x03, 0x05, 0x05, 0xFF,
			0x03, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01, 0x00, 0x01, 0x07,
			0x01, 0xEC, 0x01, 0xED, 0x01, 0x12, 0x01, 0xF7, 0x02, 0xFF,
			0x01, 0x11, 0x01, 0x07, 0x04, 0x15, 0x02, 0x43, 0x20, 0x00,
			0x01, 0x05, 0x01, 0xFF, 0x03, 0x05, 0x05, 0xFF, 0x03, 0x05,
			0x02, 0xFF, 0x01, 0x05, 0x01, 0x00, 0x01, 0x07, 0x02, 0x14,
			0x01, 0x12, 0x01, 0xEF, 0x01, 0xFF, 0x01, 0xF5, 0x01, 0xF4,
			0x01, 0x14, 0x01, 0xF1, 0x01, 0x66, 0x01, 0xF2, 0x01, 0xF8,
			0x01, 0xF4, 0x01, 0x12, 0x20, 0x00, 0x01, 0x05, 0x01, 0xFF,
			0x03, 0x05, 0x05, 0xFF, 0x03, 0x05, 0x02, 0xFF, 0x01, 0x05,
			0x01, 0x00, 0x01, 0xF7, 0x02, 0xF4, 0x01, 0x6D, 0x01, 0xED,
			0x01, 0x91, 0x02, 0xAE, 0x01, 0x6D, 0x04, 0x66, 0x02, 0x43,
			0x20, 0x00, 0x01, 0x05, 0x0E, 0xFF, 0x01, 0x05, 0x01, 0x00,
			0x01, 0xEC, 0x01, 0xED, 0x03, 0x92, 0x01, 0xED, 0x02, 0xAE,
			0x01, 0x6D, 0x01, 0xEA, 0x03, 0x66, 0x01, 0x15, 0x01, 0x43,
			0x20, 0x00, 0x10, 0x05, 0x30, 0x00, 0x01, 0x42, 0x01, 0x4D,
			0x01, 0x3E, 0x07, 0x00, 0x01, 0x3E, 0x03, 0x00, 0x01, 0x28,
			0x03, 0x00, 0x01, 0x40, 0x03, 0x00, 0x01, 0x20, 0x03, 0x00,
			0x01, 0x01, 0x01, 0x00, 0x01, 0x01, 0x06, 0x00, 0x01, 0x01,
			0x16, 0x00, 0x03, 0xFF, 0xFF, 0x00, 0x02, 0x00, 0x0B };
#else
			0x00, 0x01, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x01,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C, 0x02, 0x00,
			0x00, 0x00, 0x5A, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E,
			0x57, 0x69, 0x6E, 0x64, 0x6F, 0x77, 0x73, 0x2E, 0x46, 0x6F,
			0x72, 0x6D, 0x73, 0x2C, 0x20, 0x56, 0x65, 0x72, 0x73, 0x69,
			0x6F, 0x6E, 0x3D, 0x31, 0x2E, 0x30, 0x2E, 0x35, 0x30, 0x30,
			0x30, 0x2E, 0x30, 0x2C, 0x20, 0x43, 0x75, 0x6C, 0x74, 0x75,
			0x72, 0x65, 0x3D, 0x6E, 0x65, 0x75, 0x74, 0x72, 0x61, 0x6C,
			0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65,
			0x79, 0x54, 0x6F, 0x6B, 0x65, 0x6E, 0x3D, 0x62, 0x37, 0x37,
			0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65,
			0x30, 0x38, 0x39, 0x05, 0x01, 0x00, 0x00, 0x00, 0x26, 0x53,
			0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x57, 0x69, 0x6E, 0x64,
			0x6F, 0x77, 0x73, 0x2E, 0x46, 0x6F, 0x72, 0x6D, 0x73, 0x2E,
			0x49, 0x6D, 0x61, 0x67, 0x65, 0x4C, 0x69, 0x73, 0x74, 0x53,
			0x74, 0x72, 0x65, 0x61, 0x6D, 0x65, 0x72, 0x01, 0x00, 0x00,
			0x00, 0x04, 0x44, 0x61, 0x74, 0x61, 0x07, 0x02, 0x02, 0x00,
			0x00, 0x00, 0x09, 0x03, 0x00, 0x00, 0x00, 0x0F, 0x03, 0x00,
			0x00, 0x00, 0x0A, 0x09, 0x00, 0x00, 0x02, 0x4D, 0x53, 0x46,
			0x74, 0x01, 0x49, 0x01, 0x4C, 0x02, 0x01, 0x01, 0x02, 0x01,
			0x00, 0x01, 0x05, 0x01, 0x00, 0x01, 0x04, 0x01, 0x00, 0x01,
			0x10, 0x01, 0x00, 0x01, 0x10, 0x01, 0x00, 0x04, 0xFF, 0x01,
			0x09, 0x01, 0x00, 0x08, 0xFF, 0x01, 0x42, 0x01, 0x4D, 0x01,
			0x36, 0x01, 0x04, 0x06, 0x00, 0x01, 0x36, 0x01, 0x04, 0x02,
			0x00, 0x01, 0x28, 0x03, 0x00, 0x01, 0x40, 0x03, 0x00, 0x01,
			0x20, 0x03, 0x00, 0x01, 0x01, 0x01, 0x00, 0x01, 0x08, 0x06,
			0x00, 0x01, 0x08, 0x18, 0x00, 0x01, 0x80, 0x02, 0x00, 0x01,
			0x80, 0x03, 0x00, 0x02, 0x80, 0x01, 0x00, 0x01, 0x80, 0x03,
			0x00, 0x01, 0x80, 0x01, 0x00, 0x01, 0x80, 0x01, 0x00, 0x02,
			0x80, 0x02, 0x00, 0x03, 0xC0, 0x01, 0x00, 0x01, 0xC0, 0x01,
			0xDC, 0x01, 0xC0, 0x01, 0x00, 0x01, 0xF0, 0x01, 0xCA, 0x01,
			0xA6, 0x01, 0x00, 0x01, 0x33, 0x05, 0x00, 0x01, 0x33, 0x01,
			0x00, 0x01, 0x33, 0x01, 0x00, 0x01, 0x33, 0x01, 0x00, 0x02,
			0x33, 0x02, 0x00, 0x03, 0x16, 0x01, 0x00, 0x03, 0x1C, 0x01,
			0x00, 0x03, 0x22, 0x01, 0x00, 0x03, 0x29, 0x01, 0x00, 0x03,
			0x55, 0x01, 0x00, 0x03, 0x4D, 0x01, 0x00, 0x03, 0x42, 0x01,
			0x00, 0x03, 0x39, 0x01, 0x00, 0x01, 0x80, 0x01, 0x7C, 0x01,
			0xFF, 0x01, 0x00, 0x02, 0x50, 0x01, 0xFF, 0x01, 0x00, 0x01,
			0x93, 0x01, 0x00, 0x01, 0xD6, 0x01, 0x00, 0x01, 0xFF, 0x01,
			0xEC, 0x01, 0xCC, 0x01, 0x00, 0x01, 0xC6, 0x01, 0xD6, 0x01,
			0xEF, 0x01, 0x00, 0x01, 0xD6, 0x02, 0xE7, 0x01, 0x00, 0x01,
			0x90, 0x01, 0xA9, 0x01, 0xAD, 0x02, 0x00, 0x01, 0xFF, 0x01,
			0x33, 0x03, 0x00, 0x01, 0x66, 0x03, 0x00, 0x01, 0x99, 0x03,
			0x00, 0x01, 0xCC, 0x02, 0x00, 0x01, 0x33, 0x03, 0x00, 0x02,
			0x33, 0x02, 0x00, 0x01, 0x33, 0x01, 0x66, 0x02, 0x00, 0x01,
			0x33, 0x01, 0x99, 0x02, 0x00, 0x01, 0x33, 0x01, 0xCC, 0x02,
			0x00, 0x01, 0x33, 0x01, 0xFF, 0x02, 0x00, 0x01, 0x66, 0x03,
			0x00, 0x01, 0x66, 0x01, 0x33, 0x02, 0x00, 0x02, 0x66, 0x02,
			0x00, 0x01, 0x66, 0x01, 0x99, 0x02, 0x00, 0x01, 0x66, 0x01,
			0xCC, 0x02, 0x00, 0x01, 0x66, 0x01, 0xFF, 0x02, 0x00, 0x01,
			0x99, 0x03, 0x00, 0x01, 0x99, 0x01, 0x33, 0x02, 0x00, 0x01,
			0x99, 0x01, 0x66, 0x02, 0x00, 0x02, 0x99, 0x02, 0x00, 0x01,
			0x99, 0x01, 0xCC, 0x02, 0x00, 0x01, 0x99, 0x01, 0xFF, 0x02,
			0x00, 0x01, 0xCC, 0x03, 0x00, 0x01, 0xCC, 0x01, 0x33, 0x02,
			0x00, 0x01, 0xCC, 0x01, 0x66, 0x02, 0x00, 0x01, 0xCC, 0x01,
			0x99, 0x02, 0x00, 0x02, 0xCC, 0x02, 0x00, 0x01, 0xCC, 0x01,
			0xFF, 0x02, 0x00, 0x01, 0xFF, 0x01, 0x66, 0x02, 0x00, 0x01,
			0xFF, 0x01, 0x99, 0x02, 0x00, 0x01, 0xFF, 0x01, 0xCC, 0x01,
			0x00, 0x01, 0x33, 0x01, 0xFF, 0x02, 0x00, 0x01, 0xFF, 0x01,
			0x00, 0x01, 0x33, 0x01, 0x00, 0x01, 0x33, 0x01, 0x00, 0x01,
			0x66, 0x01, 0x00, 0x01, 0x33, 0x01, 0x00, 0x01, 0x99, 0x01,
			0x00, 0x01, 0x33, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01,
			0x33, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x00, 0x01, 0xFF, 0x01,
			0x33, 0x02, 0x00, 0x03, 0x33, 0x01, 0x00, 0x02, 0x33, 0x01,
			0x66, 0x01, 0x00, 0x02, 0x33, 0x01, 0x99, 0x01, 0x00, 0x02,
			0x33, 0x01, 0xCC, 0x01, 0x00, 0x02, 0x33, 0x01, 0xFF, 0x01,
			0x00, 0x01, 0x33, 0x01, 0x66, 0x02, 0x00, 0x01, 0x33, 0x01,
			0x66, 0x01, 0x33, 0x01, 0x00, 0x01, 0x33, 0x02, 0x66, 0x01,
			0x00, 0x01, 0x33, 0x01, 0x66, 0x01, 0x99, 0x01, 0x00, 0x01,
			0x33, 0x01, 0x66, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x33, 0x01,
			0x66, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x33, 0x01, 0x99, 0x02,
			0x00, 0x01, 0x33, 0x01, 0x99, 0x01, 0x33, 0x01, 0x00, 0x01,
			0x33, 0x01, 0x99, 0x01, 0x66, 0x01, 0x00, 0x01, 0x33, 0x02,
			0x99, 0x01, 0x00, 0x01, 0x33, 0x01, 0x99, 0x01, 0xCC, 0x01,
			0x00, 0x01, 0x33, 0x01, 0x99, 0x01, 0xFF, 0x01, 0x00, 0x01,
			0x33, 0x01, 0xCC, 0x02, 0x00, 0x01, 0x33, 0x01, 0xCC, 0x01,
			0x33, 0x01, 0x00, 0x01, 0x33, 0x01, 0xCC, 0x01, 0x66, 0x01,
			0x00, 0x01, 0x33, 0x01, 0xCC, 0x01, 0x99, 0x01, 0x00, 0x01,
			0x33, 0x02, 0xCC, 0x01, 0x00, 0x01, 0x33, 0x01, 0xCC, 0x01,
			0xFF, 0x01, 0x00, 0x01, 0x33, 0x01, 0xFF, 0x01, 0x33, 0x01,
			0x00, 0x01, 0x33, 0x01, 0xFF, 0x01, 0x66, 0x01, 0x00, 0x01,
			0x33, 0x01, 0xFF, 0x01, 0x99, 0x01, 0x00, 0x01, 0x33, 0x01,
			0xFF, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x33, 0x02, 0xFF, 0x01,
			0x00, 0x01, 0x66, 0x03, 0x00, 0x01, 0x66, 0x01, 0x00, 0x01,
			0x33, 0x01, 0x00, 0x01, 0x66, 0x01, 0x00, 0x01, 0x66, 0x01,
			0x00, 0x01, 0x66, 0x01, 0x00, 0x01, 0x99, 0x01, 0x00, 0x01,
			0x66, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x66, 0x01,
			0x00, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x66, 0x01, 0x33, 0x02,
			0x00, 0x01, 0x66, 0x02, 0x33, 0x01, 0x00, 0x01, 0x66, 0x01,
			0x33, 0x01, 0x66, 0x01, 0x00, 0x01, 0x66, 0x01, 0x33, 0x01,
			0x99, 0x01, 0x00, 0x01, 0x66, 0x01, 0x33, 0x01, 0xCC, 0x01,
			0x00, 0x01, 0x66, 0x01, 0x33, 0x01, 0xFF, 0x01, 0x00, 0x02,
			0x66, 0x02, 0x00, 0x02, 0x66, 0x01, 0x33, 0x01, 0x00, 0x03,
			0x66, 0x01, 0x00, 0x02, 0x66, 0x01, 0x99, 0x01, 0x00, 0x02,
			0x66, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x66, 0x01, 0x99, 0x02,
			0x00, 0x01, 0x66, 0x01, 0x99, 0x01, 0x33, 0x01, 0x00, 0x01,
			0x66, 0x01, 0x99, 0x01, 0x66, 0x01, 0x00, 0x01, 0x66, 0x02,
			0x99, 0x01, 0x00, 0x01, 0x66, 0x01, 0x99, 0x01, 0xCC, 0x01,
			0x00, 0x01, 0x66, 0x01, 0x99, 0x01, 0xFF, 0x01, 0x00, 0x01,
			0x66, 0x01, 0xCC, 0x02, 0x00, 0x01, 0x66, 0x01, 0xCC, 0x01,
			0x33, 0x01, 0x00, 0x01, 0x66, 0x01, 0xCC, 0x01, 0x99, 0x01,
			0x00, 0x01, 0x66, 0x02, 0xCC, 0x01, 0x00, 0x01, 0x66, 0x01,
			0xCC, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x66, 0x01, 0xFF, 0x02,
			0x00, 0x01, 0x66, 0x01, 0xFF, 0x01, 0x33, 0x01, 0x00, 0x01,
			0x66, 0x01, 0xFF, 0x01, 0x99, 0x01, 0x00, 0x01, 0x66, 0x01,
			0xFF, 0x01, 0xCC, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01,
			0xFF, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x00, 0x01, 0xCC, 0x01,
			0x00, 0x02, 0x99, 0x02, 0x00, 0x01, 0x99, 0x01, 0x33, 0x01,
			0x99, 0x01, 0x00, 0x01, 0x99, 0x01, 0x00, 0x01, 0x99, 0x01,
			0x00, 0x01, 0x99, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01,
			0x99, 0x03, 0x00, 0x01, 0x99, 0x02, 0x33, 0x01, 0x00, 0x01,
			0x99, 0x01, 0x00, 0x01, 0x66, 0x01, 0x00, 0x01, 0x99, 0x01,
			0x33, 0x01, 0xCC, 0x01, 0x00, 0x01, 0x99, 0x01, 0x00, 0x01,
			0xFF, 0x01, 0x00, 0x01, 0x99, 0x01, 0x66, 0x02, 0x00, 0x01,
			0x99, 0x01, 0x66, 0x01, 0x33, 0x01, 0x00, 0x01, 0x99, 0x01,
			0x33, 0x01, 0x66, 0x01, 0x00, 0x01, 0x99, 0x01, 0x66, 0x01,
			0x99, 0x01, 0x00, 0x01, 0x99, 0x01, 0x66, 0x01, 0xCC, 0x01,
			0x00, 0x01, 0x99, 0x01, 0x33, 0x01, 0xFF, 0x01, 0x00, 0x02,
			0x99, 0x01, 0x33, 0x01, 0x00, 0x02, 0x99, 0x01, 0x66, 0x01,
			0x00, 0x03, 0x99, 0x01, 0x00, 0x02, 0x99, 0x01, 0xCC, 0x01,
			0x00, 0x02, 0x99, 0x01, 0xFF, 0x01, 0x00, 0x01, 0x99, 0x01,
			0xCC, 0x02, 0x00, 0x01, 0x99, 0x01, 0xCC, 0x01, 0x33, 0x01,
			0x00, 0x01, 0x66, 0x01, 0xCC, 0x01, 0x66, 0x01, 0x00, 0x01,
			0x99, 0x01, 0xCC, 0x01, 0x99, 0x01, 0x00, 0x01, 0x99, 0x02,
			0xCC, 0x01, 0x00, 0x01, 0x99, 0x01, 0xCC, 0x01, 0xFF, 0x01,
			0x00, 0x01, 0x99, 0x01, 0xFF, 0x02, 0x00, 0x01, 0x99, 0x01,
			0xFF, 0x01, 0x33, 0x01, 0x00, 0x01, 0x99, 0x01, 0xCC, 0x01,
			0x66, 0x01, 0x00, 0x01, 0x99, 0x01, 0xFF, 0x01, 0x99, 0x01,
			0x00, 0x01, 0x99, 0x01, 0xFF, 0x01, 0xCC, 0x01, 0x00, 0x01,
			0x99, 0x02, 0xFF, 0x01, 0x00, 0x01, 0xCC, 0x03, 0x00, 0x01,
			0x99, 0x01, 0x00, 0x01, 0x33, 0x01, 0x00, 0x01, 0xCC, 0x01,
			0x00, 0x01, 0x66, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01,
			0x99, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x00, 0x01, 0xCC, 0x01,
			0x00, 0x01, 0x99, 0x01, 0x33, 0x02, 0x00, 0x01, 0xCC, 0x02,
			0x33, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x33, 0x01, 0x66, 0x01,
			0x00, 0x01, 0xCC, 0x01, 0x33, 0x01, 0x99, 0x01, 0x00, 0x01,
			0xCC, 0x01, 0x33, 0x01, 0xCC, 0x01, 0x00, 0x01, 0xCC, 0x01,
			0x33, 0x01, 0xFF, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x66, 0x02,
			0x00, 0x01, 0xCC, 0x01, 0x66, 0x01, 0x33, 0x01, 0x00, 0x01,
			0x99, 0x02, 0x66, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x66, 0x01,
			0x99, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x66, 0x01, 0xCC, 0x01,
			0x00, 0x01, 0x99, 0x01, 0x66, 0x01, 0xFF, 0x01, 0x00, 0x01,
			0xCC, 0x01, 0x99, 0x02, 0x00, 0x01, 0xCC, 0x01, 0x99, 0x01,
			0x33, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x99, 0x01, 0x66, 0x01,
			0x00, 0x01, 0xCC, 0x02, 0x99, 0x01, 0x00, 0x01, 0xCC, 0x01,
			0x99, 0x01, 0xCC, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x99, 0x01,
			0xFF, 0x01, 0x00, 0x02, 0xCC, 0x02, 0x00, 0x02, 0xCC, 0x01,
			0x33, 0x01, 0x00, 0x02, 0xCC, 0x01, 0x66, 0x01, 0x00, 0x02,
			0xCC, 0x01, 0x99, 0x01, 0x00, 0x03, 0xCC, 0x01, 0x00, 0x02,
			0xCC, 0x01, 0xFF, 0x01, 0x00, 0x01, 0xCC, 0x01, 0xFF, 0x02,
			0x00, 0x01, 0xCC, 0x01, 0xFF, 0x01, 0x33, 0x01, 0x00, 0x01,
			0x99, 0x01, 0xFF, 0x01, 0x66, 0x01, 0x00, 0x01, 0xCC, 0x01,
			0xFF, 0x01, 0x99, 0x01, 0x00, 0x01, 0xCC, 0x01, 0xFF, 0x01,
			0xCC, 0x01, 0x00, 0x01, 0xCC, 0x02, 0xFF, 0x01, 0x00, 0x01,
			0xCC, 0x01, 0x00, 0x01, 0x33, 0x01, 0x00, 0x01, 0xFF, 0x01,
			0x00, 0x01, 0x66, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x00, 0x01,
			0x99, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x33, 0x02, 0x00, 0x01,
			0xFF, 0x02, 0x33, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x33, 0x01,
			0x66, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x33, 0x01, 0x99, 0x01,
			0x00, 0x01, 0xFF, 0x01, 0x33, 0x01, 0xCC, 0x01, 0x00, 0x01,
			0xFF, 0x01, 0x33, 0x01, 0xFF, 0x01, 0x00, 0x01, 0xFF, 0x01,
			0x66, 0x02, 0x00, 0x01, 0xFF, 0x01, 0x66, 0x01, 0x33, 0x01,
			0x00, 0x01, 0xCC, 0x02, 0x66, 0x01, 0x00, 0x01, 0xFF, 0x01,
			0x66, 0x01, 0x99, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x66, 0x01,
			0xCC, 0x01, 0x00, 0x01, 0xCC, 0x01, 0x66, 0x01, 0xFF, 0x01,
			0x00, 0x01, 0xFF, 0x01, 0x99, 0x02, 0x00, 0x01, 0xFF, 0x01,
			0x99, 0x01, 0x33, 0x01, 0x00, 0x01, 0xFF, 0x01, 0x99, 0x01,
			0x66, 0x01, 0x00, 0x01, 0xFF, 0x02, 0x99, 0x01, 0x00, 0x01,
			0xFF, 0x01, 0x99, 0x01, 0xCC, 0x01, 0x00, 0x01, 0xFF, 0x01,
			0x99, 0x01, 0xFF, 0x01, 0x00, 0x01, 0xFF, 0x01, 0xCC, 0x02,
			0x00, 0x01, 0xFF, 0x01, 0xCC, 0x01, 0x33, 0x01, 0x00, 0x01,
			0xFF, 0x01, 0xCC, 0x01, 0x66, 0x01, 0x00, 0x01, 0xFF, 0x01,
			0xCC, 0x01, 0x99, 0x01, 0x00, 0x01, 0xFF, 0x02, 0xCC, 0x01,
			0x00, 0x01, 0xFF, 0x01, 0xCC, 0x01, 0xFF, 0x01, 0x00, 0x02,
			0xFF, 0x01, 0x33, 0x01, 0x00, 0x01, 0xCC, 0x01, 0xFF, 0x01,
			0x66, 0x01, 0x00, 0x02, 0xFF, 0x01, 0x99, 0x01, 0x00, 0x02,
			0xFF, 0x01, 0xCC, 0x01, 0x00, 0x02, 0x66, 0x01, 0xFF, 0x01,
			0x00, 0x01, 0x66, 0x01, 0xFF, 0x01, 0x66, 0x01, 0x00, 0x01,
			0x66, 0x02, 0xFF, 0x01, 0x00, 0x01, 0xFF, 0x02, 0x66, 0x01,
			0x00, 0x01, 0xFF, 0x01, 0x66, 0x01, 0xFF, 0x01, 0x00, 0x02,
			0xFF, 0x01, 0x66, 0x01, 0x00, 0x01, 0x21, 0x01, 0x00, 0x01,
			0xA5, 0x01, 0x00, 0x03, 0x5F, 0x01, 0x00, 0x03, 0x77, 0x01,
			0x00, 0x03, 0x86, 0x01, 0x00, 0x03, 0x96, 0x01, 0x00, 0x03,
			0xCB, 0x01, 0x00, 0x03, 0xB2, 0x01, 0x00, 0x03, 0xD7, 0x01,
			0x00, 0x03, 0xDD, 0x01, 0x00, 0x03, 0xE3, 0x01, 0x00, 0x03,
			0xEA, 0x01, 0x00, 0x03, 0xF1, 0x01, 0x00, 0x03, 0xF8, 0x01,
			0x00, 0x01, 0xF0, 0x01, 0xFB, 0x01, 0xFF, 0x01, 0x00, 0x01,
			0xA4, 0x02, 0xA0, 0x01, 0x00, 0x03, 0x80, 0x03, 0x00, 0x01,
			0xFF, 0x02, 0x00, 0x01, 0xFF, 0x03, 0x00, 0x02, 0xFF, 0x01,
			0x00, 0x01, 0xFF, 0x03, 0x00, 0x01, 0xFF, 0x01, 0x00, 0x01,
			0xFF, 0x01, 0x00, 0x02, 0xFF, 0x02, 0x00, 0x03, 0xFF, 0xFF,
			0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0x05, 0x00, 0x10,
			0x05, 0x01, 0x00, 0x04, 0xF8, 0x01, 0xAE, 0x01, 0xF8, 0x01,
			0xAE, 0x04, 0x6D, 0x04, 0xEA, 0x20, 0x00, 0x01, 0x05, 0x0E,
			0xFF, 0x01, 0x05, 0x01, 0x00, 0x01, 0xEA, 0x02, 0xEB, 0x01,
			0xEF, 0x01, 0xF8, 0x01, 0xED, 0x01, 0xF8, 0x01, 0xED, 0x01,
			0x6D, 0x02, 0xEC, 0x01, 0x13, 0x01, 0xED, 0x01, 0x12, 0x01,
			0x15, 0x20, 0x00, 0x01, 0x05, 0x08, 0xFF, 0x04, 0x05, 0x02,
			0xFF, 0x01, 0x05, 0x01, 0x00, 0x01, 0x59, 0x01, 0xF7, 0x01,
			0xEB, 0x02, 0xED, 0x01, 0x07, 0x01, 0xEF, 0x01, 0x92, 0x01,
			0xF8, 0x01, 0x07, 0x01, 0xED, 0x01, 0xEA, 0x01, 0xF8, 0x01,
			0x13, 0x01, 0x59, 0x20, 0x00, 0x01, 0x05, 0x07, 0xFF, 0x05,
			0x05, 0x02, 0xFF, 0x01, 0x05, 0x01, 0x00, 0x01, 0x43, 0x06,
			0x91, 0x03, 0xAE, 0x02, 0x6D, 0x02, 0xEA, 0x01, 0x43, 0x20,
			0x00, 0x01, 0x05, 0x06, 0xFF, 0x06, 0x05, 0x02, 0xFF, 0x01,
			0x05, 0x01, 0x00, 0x01, 0xAE, 0x01, 0xEB, 0x05, 0xAE, 0x02,
			0x6C, 0x03, 0x66, 0x02, 0x15, 0x01, 0x43, 0x20, 0x00, 0x01,
			0x05, 0x05, 0xFF, 0x07, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01,
			0x00, 0x01, 0xAE, 0x02, 0x6D, 0x03, 0xAE, 0x01, 0x8B, 0x01,
			0x6C, 0x03, 0x66, 0x01, 0x15, 0x01, 0x43, 0x02, 0x11, 0x20,
			0x00, 0x01, 0x05, 0x04, 0xFF, 0x08, 0x05, 0x02, 0xFF, 0x01,
			0x05, 0x01, 0x00, 0x01, 0xAE, 0x02, 0xF1, 0x01, 0x14, 0x05,
			0xAE, 0x01, 0x66, 0x01, 0xEA, 0x01, 0x15, 0x01, 0x14, 0x01,
			0x15, 0x01, 0x11, 0x20, 0x00, 0x01, 0x05, 0x03, 0xFF, 0x05,
			0x05, 0x01, 0xFF, 0x03, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01,
			0x00, 0x01, 0xAE, 0x01, 0xFF, 0x01, 0xAE, 0x01, 0x12, 0x01,
			0xF7, 0x01, 0xEF, 0x01, 0x07, 0x01, 0x6D, 0x01, 0xF7, 0x01,
			0x6D, 0x01, 0xEA, 0x01, 0xEB, 0x01, 0xEF, 0x01, 0x12, 0x01,
			0x11, 0x20, 0x00, 0x01, 0x05, 0x02, 0xFF, 0x05, 0x05, 0x02,
			0xFF, 0x03, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01, 0x00, 0x02,
			0xAE, 0x01, 0x92, 0x01, 0x12, 0x01, 0x91, 0x02, 0xAE, 0x01,
			0x8B, 0x01, 0x6C, 0x03, 0x66, 0x01, 0x15, 0x01, 0x43, 0x01,
			0x11, 0x20, 0x00, 0x01, 0x05, 0x01, 0xFF, 0x05, 0x05, 0x03,
			0xFF, 0x03, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01, 0x00, 0x01,
			0xAE, 0x02, 0x91, 0x01, 0x12, 0x01, 0xEB, 0x02, 0xEF, 0x01,
			0xED, 0x01, 0x43, 0x01, 0x66, 0x01, 0x43, 0x01, 0x07, 0x01,
			0x13, 0x01, 0xF7, 0x01, 0x11, 0x20, 0x00, 0x01, 0x05, 0x01,
			0xFF, 0x04, 0x05, 0x04, 0xFF, 0x03, 0x05, 0x02, 0xFF, 0x01,
			0x05, 0x01, 0x00, 0x01, 0x6D, 0x02, 0xEC, 0x01, 0x12, 0x01,
			0xF7, 0x02, 0xFF, 0x02, 0xED, 0x01, 0x66, 0x03, 0x43, 0x01,
			0x14, 0x01, 0x11, 0x20, 0x00, 0x01, 0x05, 0x01, 0xFF, 0x03,
			0x05, 0x05, 0xFF, 0x03, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01,
			0x00, 0x01, 0x07, 0x01, 0xEC, 0x01, 0xED, 0x01, 0x12, 0x01,
			0xF7, 0x02, 0xFF, 0x01, 0x11, 0x01, 0x07, 0x04, 0x15, 0x02,
			0x43, 0x20, 0x00, 0x01, 0x05, 0x01, 0xFF, 0x03, 0x05, 0x05,
			0xFF, 0x03, 0x05, 0x02, 0xFF, 0x01, 0x05, 0x01, 0x00, 0x01,
			0x07, 0x02, 0x14, 0x01, 0x12, 0x01, 0xEF, 0x01, 0xFF, 0x01,
			0xF5, 0x01, 0xF4, 0x01, 0x14, 0x01, 0xF1, 0x01, 0x66, 0x01,
			0xF2, 0x01, 0xF8, 0x01, 0xF4, 0x01, 0x12, 0x20, 0x00, 0x01,
			0x05, 0x01, 0xFF, 0x03, 0x05, 0x05, 0xFF, 0x03, 0x05, 0x02,
			0xFF, 0x01, 0x05, 0x01, 0x00, 0x01, 0xF7, 0x02, 0xF4, 0x01,
			0x6D, 0x01, 0xED, 0x01, 0x91, 0x02, 0xAE, 0x01, 0x6D, 0x04,
			0x66, 0x02, 0x43, 0x20, 0x00, 0x01, 0x05, 0x0E, 0xFF, 0x01,
			0x05, 0x01, 0x00, 0x01, 0xEC, 0x01, 0xED, 0x03, 0x92, 0x01,
			0xED, 0x02, 0xAE, 0x01, 0x6D, 0x01, 0xEA, 0x03, 0x66, 0x01,
			0x15, 0x01, 0x43, 0x20, 0x00, 0x10, 0x05, 0x30, 0x00, 0x01,
			0x42, 0x01, 0x4D, 0x01, 0x3E, 0x07, 0x00, 0x01, 0x3E, 0x03,
			0x00, 0x01, 0x28, 0x03, 0x00, 0x01, 0x40, 0x03, 0x00, 0x01,
			0x20, 0x03, 0x00, 0x01, 0x01, 0x01, 0x00, 0x01, 0x01, 0x06,
			0x00, 0x01, 0x01, 0x16, 0x00, 0x03, 0xFF, 0xFF, 0x00, 0x02,
			0x00, 0x0B };
#endif
	}
}