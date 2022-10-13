using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.br.com.projeto.model
{
    public class Helpers
    {
        public void LimparTela(Form tela)
        {
            // Percorre todos os controles que estão na tela
            foreach(Control ctrPai in tela.Controls)
            {
                // Vai chamar cada controle da tela de ctr1
                foreach(Control ctr1 in ctrPai.Controls)
                {
                    // Verifica se existe nesse controles um TabPage
                    if (ctr1 is TabPage)
                    {
                        // Percorre cada contrle do TabPage
                        foreach(Control ctr2 in ctr1.Controls)
                        {
                            // Verifica quais destes controles são TextBox
                            if (ctr2 is TextBox)
                            {
                                // Limpa os Textbox
                                (ctr2 as TextBox).Text = String.Empty;
  
                            }

                            // Verifica quais destes controles são MaskedTextBox
                            if (ctr2 is MaskedTextBox)
                            {
                                // Limpa os MaskedTextbox
                                (ctr2 as MaskedTextBox).Text = String.Empty;
                            }

                            // Verifica quais destes controles são ComboBox
                            if (ctr2 is ComboBox)
                            {
                                // Limpa os ComboBox
                                (ctr2 as ComboBox).Text = String.Empty;
                            }

                            // Verifica quais destes controles são CheckBox
                            if (ctr2 is CheckBox)
                            {
                                // Limpa os ComboBox
                                (ctr2 as CheckBox).Checked = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
