using Microsoft.AspNetCore.Mvc;
using portfolio.Models;
using portfolio.services;
using System.Diagnostics;

namespace portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger,IRepositorioProyectos repositorioProyectos,IServicioEmail servicioEmail)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Este es un mensaje del log");
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            

            var modelo = new HomeIndexDTO() {
                proyectos = proyectos,
            };
            
            return View(modelo);
        }


        public IActionResult Proyectos()
        {
            var proyectos=repositorioProyectos.ObtenerProyectos();
            
            return View(proyectos);
        }

        [HttpGet]
        public IActionResult Contacto()
        {           
            return View();
        }

        [HttpPost]
          public async Task<IActionResult> Contacto(ContactoDTO contacto)
        {
            await servicioEmail.Enviar(contacto);
            return RedirectToAction("Gracias");
        }
        
        public IActionResult Gracias()
        {
            return View();
        }
         

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}