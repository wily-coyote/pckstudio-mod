﻿using OMI.Formats.GameRule;
using System;
using System.Windows.Forms;

namespace PckStudio.Forms.Additional_Popups.Grf {
	public partial class AddParameter : Form {
		public string ParameterName => NameTextBox.Text;
		public string ParameterValue => ValueTextBox.Text;


		public AddParameter() {
			InitializeComponent();
			NameTextBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
			NameTextBox.AutoCompleteCustomSource.AddRange(GameRuleFile.GameRule.ValidParameters);
		}

		public AddParameter(string parameterName, string parameterValue, bool isKeyReadonly = true) : this() {
			NameTextBox.Text = parameterName;
			ValueTextBox.Text = parameterValue;
			NameTextBox.Enabled = isKeyReadonly;
		}

		private void ConfirmButton_Click(object sender, EventArgs e) {
			if(string.IsNullOrWhiteSpace(ParameterName) || string.IsNullOrWhiteSpace(ParameterValue)) {
				MessageBox.Show(this, "Name or value can't be empty.", "Empty value", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			DialogResult = DialogResult.OK;
		}
	}
}
