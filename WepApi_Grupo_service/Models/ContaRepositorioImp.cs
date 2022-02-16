using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepApi_Grupo_service.Models
{
    public class ContaRepositorioImp : ContaRepositorio
    {
        private List<Conta> contas = new List<Conta>();
        private int _nextId = 1;
        public ContaRepositorioImp()
        {
            Add(new Conta { nome = "Leonardo", id = 1, genero = "Masculino", idade = 23 });
            Add(new Conta { nome = "Matheus", id = 2, genero = "Masculino", idade = 20 });
            Add(new Conta { nome = "Miriam", id = 3, genero = "Feminino", idade = 35 });
            Add(new Conta { nome = "Janice", id = 4, genero = "Feminino", idade = 21 });
            Add(new Conta { nome = "Jessica", id = 5, genero = "Feminino", idade = 25 });
        }
        public IEnumerable<Conta> GetAll()
        {
            return contas;
        }
        public Conta Get(int id)
        {
            return contas.Find(s => s.id == id);
        }
        public bool Add(Conta conta)
        {
            bool addResult = false;
            if (conta == null)
            {
                return addResult;
            }
            int index = contas.FindIndex(s => s.id == conta.id);
            if (index == -1)
            {
                contas.Add(conta);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;
            }
        }

        public void Remove(int id)
        {
            contas.RemoveAll(s => s.id == id);
        }
        public bool Update(Conta conta)
        {
            if (conta == null)
            {
                throw new ArgumentNullException("conta");
            }
            int index = contas.FindIndex(s => s.id == conta.id);
            if (index == -1)
            {
                return false;
            }
            contas.RemoveAt(index);
            contas.Add(conta);
            return true;
        }
    }
}