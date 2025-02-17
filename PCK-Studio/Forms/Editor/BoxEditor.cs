﻿using PckStudio.Internal;
using PckStudio.Properties;
using System;
using System.Windows.Forms;

namespace PckStudio.Forms.Editor {
	public partial class BoxEditor : Form {
		public string Result;

		public BoxEditor(string box, bool hasInflation)
			: this(SkinBOX.FromString(box), hasInflation) {
		}

		public BoxEditor(SkinBOX box, bool hasInflation) {
			InitializeComponent();

			//if(string.IsNullOrEmpty(box.Type) || !parentComboBox.Items.Contains(box.Type)) {
			//	throw new Exception("Failed to parse BOX value");
			//}

			closeButton.Visible = !Settings.Default.AutoSaveChanges;

			scaleUpDown.Enabled = hasInflation;

			parentComboBox.SelectedItem = parentComboBox.Items[parentComboBox.Items.IndexOf(box.Type)];
			PosXUpDown.Value = (decimal)box.Pos.X;
			PosYUpDown.Value = (decimal)box.Pos.Y;
			PosZUpDown.Value = (decimal)box.Pos.Z;
			SizeXUpDown.Value = (decimal)box.Size.X;
			SizeYUpDown.Value = (decimal)box.Size.Y;
			SizeZUpDown.Value = (decimal)box.Size.Z;
			uvXUpDown.Value = (decimal)box.UV.X;
			uvYUpDown.Value = (decimal)box.UV.Y;
			armorCheckBox.Checked = box.ArmorFlag;
			mirrorCheckBox.Checked = box.Mirror;
			scaleUpDown.Value = (decimal)box.Scale;
		}

		private void saveButton_Click(object sender, EventArgs e) {
			Result =
				$"{parentComboBox.SelectedItem} " +
				$"{PosXUpDown.Value} {PosYUpDown.Value} {PosZUpDown.Value} " +
				$"{SizeXUpDown.Value} {SizeYUpDown.Value} {SizeZUpDown.Value} " +
				$"{uvXUpDown.Value} {uvYUpDown.Value} " +
				$"{Convert.ToInt32(armorCheckBox.Checked)} " +
				$"{Convert.ToInt32(mirrorCheckBox.Checked)} " +
				$"{scaleUpDown.Value}";
			DialogResult = DialogResult.OK;
		}

		private void BoxEditor_FormClosing(object sender, FormClosingEventArgs e) {
			if(Settings.Default.AutoSaveChanges) {
				saveButton_Click(sender, EventArgs.Empty);
			}
		}
	}
}
