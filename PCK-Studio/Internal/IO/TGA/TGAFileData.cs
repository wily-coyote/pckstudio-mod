﻿/* Copyright (c) 2022-present miku-666
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1.The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
**/
using System.Drawing;
using System.IO;

namespace PckStudio.Internal.IO.TGA {
	internal class TGAFileData {
		public TGAFileData(TGAHeader header, Image bitmap, TGAFooter footer, TGAExtentionData extentionData) {
			if(bitmap.Width != header.Width || bitmap.Height != header.Height)
				throw new InvalidDataException("Header resolution doesn't match Image resolution");
			Header = header;
			Bitmap = bitmap;
			Footer = footer;
			ExtentionData = extentionData;
		}

		public readonly TGAHeader Header;
		public readonly Image Bitmap;
		public readonly TGAFooter Footer;
		public readonly TGAExtentionData ExtentionData;
	}
}