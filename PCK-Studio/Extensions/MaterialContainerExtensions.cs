﻿using OMI.Formats.Material;

namespace PckStudio.Extensions {
	internal static class MaterialContainerExtensions {
		private static readonly MaterialContainer.Material[] defaultMaterials = [
				new MaterialContainer.Material("bat", "entity_alphatest"),
				new MaterialContainer.Material("ender_dragon", "entity_emissive_alpha"),
				new MaterialContainer.Material("blaze_head", "entity_emissive_alpha"),
				new MaterialContainer.Material("drowned", "entity_emissive_alpha"),
				new MaterialContainer.Material("enderman", "entity_emissive_alpha"),
				new MaterialContainer.Material("enderman_invisible", "entity_emissive_alpha_only"),
				new MaterialContainer.Material("ghast", "entity_emissive_alpha"),
				new MaterialContainer.Material("guardian", "entity_alphatest"),
				new MaterialContainer.Material("magma_cube", "entity_emissive_alpha"),
				new MaterialContainer.Material("zombie_pigman", "entity"),
				new MaterialContainer.Material("phantom", "entity_emissive_alpha"),
				new MaterialContainer.Material("phantom_invisible", "entity_emissive_alpha_only"),
				new MaterialContainer.Material("sheep", "entity_change_color"),
				new MaterialContainer.Material("shulker", "entity_change_color"),
				new MaterialContainer.Material("skeleton", "entity_alphatest"),
				new MaterialContainer.Material("spider", "entity_emissive_alpha"),
				new MaterialContainer.Material("spider_invisible", "entity_emissive_alpha_only"),
				new MaterialContainer.Material("stray", "entity_alphatest"),
				new MaterialContainer.Material("iron_golem", "entity_alphatest"),
				new MaterialContainer.Material("wither_boss", "entity_alphatest"),
				new MaterialContainer.Material("wither_skeleton", "entity_alphatest"),
				new MaterialContainer.Material("wolf", "entity_alphatest_change_color")
			];

		public static void InitializeDefault(this MaterialContainer materials) {
			materials.AddRange(defaultMaterials);
		}
	}
}
