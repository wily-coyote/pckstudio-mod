﻿using Newtonsoft.Json;

namespace PckStudio.Internal.Json {
	internal class JsonTileInfo {
		[JsonProperty("displayName")]
		public string DisplayName { get; set; }

		[JsonProperty("internalName")]
		public string InternalName { get; set; }

		[JsonProperty("width")]
		public int TileWidth { get; set; } = 1;

		[JsonProperty("height")]
		public int TileHeight { get; set; } = 1;

		[JsonProperty("hasColourEntry", DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool HasColourEntry { get; set; }

		[JsonProperty("colourEntry", DefaultValueHandling = DefaultValueHandling.Populate)]
		public JsonColorEntry ColourEntry { get; set; }

		[JsonProperty("allowCustomColour", DefaultValueHandling = DefaultValueHandling.Populate)]
		public bool AllowCustomColour { get; set; }

		public JsonTileInfo(string displayName, string internalName) {
			DisplayName = displayName;
			InternalName = internalName;
		}
	}
}
