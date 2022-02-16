using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WepApi_Grupo_service.Models;

namespace WepApi_Grupo_service.Controllers
{
    public class ContasController : ApiController
    {
        static readonly ContaRepositorio contaRepositorio = new ContaRepositorioImp();
        public HttpResponseMessage GetAllContas()
        {
            List<Conta> listaContas = contaRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Conta>>(HttpStatusCode.OK, listaContas);
        }
        public HttpResponseMessage GetConta(int id)
        {
            Conta conta = contaRepositorio.Get(id);
            if (conta == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Conta não localizada para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Conta>(HttpStatusCode.OK, conta);
            }
        }
        public IEnumerable<Conta> GetContasPorGenero(string genero)
        {
            return contaRepositorio.GetAll().Where(
                e => string.Equals(e.genero, genero, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<Conta> GetContasPorIdade(int idade)
        {
            return contaRepositorio.GetAll().Where(
                e => string.Equals(e.idade.ToString(), idade.ToString(), StringComparison.OrdinalIgnoreCase));
        }
        public HttpResponseMessage PostConta(Conta conta)
        {
            bool result = contaRepositorio.Add(conta);
            if (result)
            {
                var response = Request.CreateResponse<Conta>(HttpStatusCode.Created, conta);
                string uri = Url.Link("DefaultApi", new { id = conta.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Conta não foi incluída com sucesso");
            }
        }
        public HttpResponseMessage PutConta(int id, Conta conta)
        {
            conta.id = id;
            if (!contaRepositorio.Update(conta))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
 "Não foi possível atualizar a conta para o id informado");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        public HttpResponseMessage DeleteConta(int id)
        {
            contaRepositorio.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}