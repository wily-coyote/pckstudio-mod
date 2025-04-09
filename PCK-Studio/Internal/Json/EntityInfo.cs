﻿using Newtonsoft.Json;

namespace PckStudio.Internal.Json {
	internal class EntityInfo {
		[JsonProperty("displayName")]
		public string DisplayName { get; set; }

		[JsonProperty("internalName")]
		public string InternalName { get; set; }

		public EntityInfo(string displayName, string internalName) {
			DisplayName = displayName;
			InternalName = internalName;
		}
	}
}
