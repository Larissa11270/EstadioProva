using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CopaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class JogosSelecoesController : ControllerBase
    {
       private readonly DataContext _context;

       public JogosSelecoesController(DataContext context)
        {
            _context = context;
        }
    }
}