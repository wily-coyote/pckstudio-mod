using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PckStudio.Forms.Additional_Popups.Loc {
	public partial class AddLanguage : Form {
		public string SelectedLanguage => LanguageComboBox.Text;

		public AddLanguage(IEnumerable<string> availableLanguages) {
			InitializeComponent();
			foreach(string lang in availableLanguages){
				LanguageComboBox.Items.Add(lang);
			}
			LanguageComboBox.SelectedIndex = 0;
		}

		private void AddBtn_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
