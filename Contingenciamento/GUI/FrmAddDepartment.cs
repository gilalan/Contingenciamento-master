using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using Contingenciamento.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmAddDepartment : Form
    {
        private Facade _facade;
        private string depCode;

        public Department Department { get; set; }

        public FrmAddDepartment()
        {
            InitializeComponent();
        }

        public FrmAddDepartment(string dptCode)
        {
            depCode = dptCode;
            InitializeComponent();
        }

        private void FrmAddDepartment_Load(object sender, EventArgs e)
        {
            _facade = new Facade();
            this.txtDptCode.Text = depCode;
        }

        private void btnSaveDepto_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtDeptName.Text) || String.IsNullOrEmpty(this.txtDptCode.Text))
                {
                    MessageBox.Show("Código e Nome do Departamento devem ser preenchidos.", "Adicionar Departamento", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    string code = this.txtDptCode.Text;
                    if (code.Length == 1 || code.Length == 2 || code.Length == 4 || code.Length == 5 || 
                        code.Length == 7 || code.Length == 8)
                    {
                        MessageBox.Show("Código do Departamento deve ter 3, 6 ou 9 dígitos.", "Adicionar Departamento",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (code.Contains(" "))
                    {
                        MessageBox.Show("Código do Departamento não pode ter espaço entre os dígitos.", "Adicionar Departamento",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Department dep = new Department(code, txtDeptName.Text);
                        long retId = _facade.InsertDepartment(dep);
                        if (retId > 0)
                        {
                            dep.Id = retId;
                            if (MessageBox.Show("Departamento cadastrado com sucesso sob o ID: " + retId, "Departamento Cadastrado com Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                Department = dep;
                                this.Close();
                            }
                            
                        } else
                        {
                            MessageBox.Show("Houve um erro ao cadastrar o Departamento.", "Erro de Cadastro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (ItemAlreadyExists itemEx)
            {
                MessageBox.Show(itemEx.Message, "Erro de Cadastro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro de Cadastro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
