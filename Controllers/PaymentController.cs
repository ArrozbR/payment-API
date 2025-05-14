using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Context;
using PaymentAPI.Models;

namespace TrilhaApiDesafio.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase{
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context){
            _context = context;
        }
    }
}