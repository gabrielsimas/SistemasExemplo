using System.Web.Http;
using WebActivatorEx;
using Apresentacao.Web.WebApi;
using Swashbuckle.Application;
using System.Reflection;
using System.IO;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace Apresentacao.Web.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory+ @"\bin\";
                        var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                        var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                        
                        c.SingleApiVersion("v1", "API Web para Gerenciamento de Tarefas")
                            .Description("API Web para Gerenciamento de Tarefas para a Parte II do artigo sobre Refactoring de uma aplicação 3 camadas para DDD")
                            .TermsOfService("http://www.devmedia.com.br/api/termos-de-uso.php")
                            .Contact(cc => cc
                            .Name("Gabriel Simas")
                            .Url("http://www.devmedia.com.br/space/luis-gabriel-nascimento-simas")
                            .Email("autorgabrielsimas@gmail.com"))
                            .License(lc => lc
                                .Name("Licença DevMedia")
                                .Url("http://www.devmedia.com.br"));

                        c.IncludeXmlComments(commentsFile);
                        c.IgnoreObsoleteActions();
                        c.DescribeAllEnumsAsStrings();                        
                    })
                .EnableSwaggerUi();
        }
    }
}
