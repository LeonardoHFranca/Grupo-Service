using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WepApi_Grupo_service.Models
{
    interface ContaRepositorio
    {
        IEnumerable<Conta> GetAll();
        Conta Get(int id);
        bool Add(Conta conta);
        void Remove(int id);
        bool Update(Conta conta);

    }
}
