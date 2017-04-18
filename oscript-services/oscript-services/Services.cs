using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.ServiceProcess;
using ScriptEngine.HostedScript.Library;

namespace oscript_services
{
    /// <summary>
    /// Работа со службами Windows
    /// </summary>
    [ContextClass("Службы", "Services")]
    public class Services : AutoContext<Services>
    {
        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor()
        {
            return new Services();
        }

        public override string ToString()
        {
            return "Службы";
        }

        /// <summary>
        /// Получить список служб Windows
        /// </summary>
        /// <returns>Массив Service</returns>
        [ContextMethod("ПолучитьСписок", "GetList")]
        public ArrayImpl GetList()
        {
            ArrayImpl array = new ArrayImpl();

            ServiceController[] scServices;
            scServices = ServiceController.GetServices();

            //Service srv = new Service();

            foreach (ServiceController srv in scServices)
            {
                array.Add(new Service(srv));
            }

            return array;

        }
    }
}
