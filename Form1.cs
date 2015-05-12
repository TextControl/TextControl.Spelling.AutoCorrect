using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TXTextControl;

namespace txspell_autocorrect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textControl1_Changed(object sender, EventArgs e)
        {
            if (correctTWoINitialCApitalsToolStripMenuItem.Checked == false)
                return;

            // loop through all misspelled words
            foreach (MisspelledWord word in textControl1.MisspelledWords)
            {
                // if the first two initials are uppercase
                if (char.IsUpper(word.Text[0]) && char.IsUpper(word.Text[1]))
                {
                    // and the word is not mispelled
                    txSpellChecker1.Check(word.Text.ToLower());

                    // replace the word
                    if (txSpellChecker1.IncorrectWords.Count == 0)
                         textControl1.MisspelledWords.Remove(word, 
                             ToUpperFirstLetter(word.Text));
                }
            }
        }

        // returns a string with the first letter uppercase
        public static string ToUpperFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            
            char[] letters = source.ToLower().ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textControl1.Selection.Culture = new System.Globalization.CultureInfo("en-US");
        }
    }
}
