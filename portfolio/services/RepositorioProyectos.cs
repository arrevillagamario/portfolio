using portfolio.Models;

namespace portfolio.services
{

    public interface IRepositorioProyectos
    {
        List<ProyectoDTO> ObtenerProyectos();
    }
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<ProyectoDTO> ObtenerProyectos()
        {
            return new List<ProyectoDTO>()
            {
                new ProyectoDTO
                {
                    titulo="Amazon",
                    descripcion="E-Commerce realizado en .Net core",
                    imagenUrl="/imagenes/amazon.PNG",
                    link="https://www.amazon.com/"
                },
                new ProyectoDTO
                {
                    titulo="New York times",
                    descripcion="Pagina de noticias en react",
                    imagenUrl="/imagenes/nyt.PNG",
                    link="https://nytimes.com"
                },
                new ProyectoDTO
                {
                    titulo="Reddit",
                    descripcion="Red social para compartir en comunidades",
                    imagenUrl="/imagenes/reddit.PNG",
                    link="https://reddit.com"
                },
                new ProyectoDTO
                {
                    titulo="Steams",
                    descripcion="Tienda en linea para comprar video juegos",
                    imagenUrl="/imagenes/steam.PNG",
                    link="https://storesteampawered.com"
                }

            };
        }
    }
}
