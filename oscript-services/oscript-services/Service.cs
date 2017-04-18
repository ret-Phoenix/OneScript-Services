using ScriptEngine.HostedScript.Library;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace oscript_services
{
    [ContextClass("Служба", "Service")]
    class Service : AutoContext<Service>
    {
        private ServiceController _service;

        public Service(IValue SrvName)
        {
            _service = new ServiceController(SrvName.AsString());
        }

        public Service(ServiceController srv)
        {
            _service = srv;

        }


        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor(IValue SrvName)
        {
            return new Service(SrvName);
        }

        public override string ToString()
        {
            return "Служба";
        }

        /// <summary>
        /// Получает или задает понятное имя службы.
        /// </summary>
        [ContextProperty("Представление", "DisplayName")]
        public string DisplayName
        {
            get { return _service.DisplayName; }
            set { _service.DisplayName = value; }
        }

        /// <summary>
        /// Получает или задает имя, определяющее службу, на которую ссылается данный экземпляр.
        /// </summary>
        [ContextProperty("Имя", "ServiceName")]
        public string ServiceName
        {
            get { return _service.ServiceName; }
            set { _service.ServiceName = value; }
        }

        /// <summary>
        /// Получает значение, показывающее, возможны ли приостановка и возобновление работы службы.
        /// </summary>
        [ContextProperty("ВозможныПриостановкаИВозобновление", "CanPauseAndContinue")]
        public bool CanPauseAndContinue
        {
            get { return _service.CanPauseAndContinue; }
        }

        /// <summary>
        /// Получает значение, показывающее, необходимо ли уведомлять службу о завершении работы системы.
        /// </summary>
        [ContextProperty("УведомлятьСлужбуОЗавершенииРаботыСистемы", "CanShutdown")]
        public bool CanShutdown
        {
            get { return _service.CanShutdown; }
        }

        /// <summary>
        /// Получает значение, определяющее, возможен ли останов службы после ее запуска.
        /// </summary>
        [ContextProperty("ВозможенОстановСлужбыПослеЗапуска", "CanStop")]
        public bool CanStop
        {
            get { return _service.CanStop; }
        }

        /// <summary>
        /// Получает набор служб, который зависит от службы, связанный с этим ServiceController экземпляра.
        /// </summary>
        [ContextProperty("ЗависимыеСлужбы", "DependentServices")]
        public ArrayImpl DependentServices
        {
            get
            {
                ArrayImpl result = new ArrayImpl();
                foreach (ServiceController srvDep in _service.DependentServices)
                {
                    result.Add(new Service(srvDep));
                }
                return result;
            }
        }

        /// <summary>
        /// Получает или задает имя компьютера, на котором находится данная служба.
        /// </summary>
        [ContextProperty("ИмяКомпьютера", "MachineName")]
        public string MachineName
        {
            get { return _service.MachineName; }
            set { _service.MachineName = value; }
        }

        /// <summary>
        /// Набор служб, от которых зависит данная служба.
        /// </summary>
        [ContextProperty("ЗависитОтСлужб", "ServicesDependedOn")]
        public ArrayImpl ServicesDependedOn
        {
            get
            {
                ArrayImpl result = new ArrayImpl();
                foreach (ServiceController srvDep in _service.ServicesDependedOn)
                {
                    result.Add(new Service(srvDep));
                }
                return result;
            }
        }


        /// <summary>
        /// Получает тип службы, на которую ссылается данный объект.
        /// Это перечисление имеет атрибут FlagsAttribute, который допускает побитовую комбинацию значений его элементов.
        /// </summary>
        [ContextProperty("ТипыСлужбы", "ServiceTypes")]
        public ArrayImpl ServiceTypes
        {
            get
            {
                ArrayImpl result = new ArrayImpl();
                if ((_service.ServiceType & System.ServiceProcess.ServiceType.Adapter) != 0)
                {
                    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["Адаптер"]);
                }
                if ((_service.ServiceType & System.ServiceProcess.ServiceType.FileSystemDriver) != 0)
                {
                    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["ДрайверФайловойСистемы"]);
                }
                if ((_service.ServiceType & System.ServiceProcess.ServiceType.InteractiveProcess) != 0)
                {
                    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["ИнтерактивныйПроцесс"]);
                }
                if ((_service.ServiceType & System.ServiceProcess.ServiceType.KernelDriver) != 0)
                {
                    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["ДрайверЯдра"]);
                }
                if ((_service.ServiceType & System.ServiceProcess.ServiceType.RecognizerDriver) != 0)
                {
                    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["ДрайверДляОпределенияФайловыхСистем"]);
                }
                if ((_service.ServiceType & System.ServiceProcess.ServiceType.Win32OwnProcess) != 0)
                {
                    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["ВозможенЗапускКонтроллеромДомена"]);
                }
                if ((_service.ServiceType & System.ServiceProcess.ServiceType.Win32ShareProcess) != 0)
                {
                    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["МожетИспользоватьПроцессСовместно"]);
                }
                return result;
            }
        }

        [ContextProperty("Статус", "Status")]
        public IValue StartType
        {
            get
            {
                var val = ValueFactory.Create();
                switch (_service.Status)
                {
                    case ServiceControllerStatus.ContinuePending: val = GlobalsManager.GetEnum<ControllerStatusEnum>()["ОжидаетВозобновления"]; break;
                    case ServiceControllerStatus.Paused: val = GlobalsManager.GetEnum<ControllerStatusEnum>()["Приостановлена"]; break;
                    case ServiceControllerStatus.PausePending: val = GlobalsManager.GetEnum<ControllerStatusEnum>()["ОстановкаСлужбы"]; break;
                    case ServiceControllerStatus.Running: val = GlobalsManager.GetEnum<ControllerStatusEnum>()["Работает"]; break;
                    case ServiceControllerStatus.StartPending: val = GlobalsManager.GetEnum<ControllerStatusEnum>()["ЗапускСлужбы"]; break;
                    case ServiceControllerStatus.Stopped: val = GlobalsManager.GetEnum<ControllerStatusEnum>()["Остановлена"]; break;
                    case ServiceControllerStatus.StopPending: val = GlobalsManager.GetEnum<ControllerStatusEnum>()["ОстановкаСлужбы"]; break;
                }
                return val;
            }

        }

        //[ContextProperty("ТипыЗапуска", "StartType")]
        //public ArrayImpl StartType
        //{
        //    get
        //    {
        //        ArrayImpl result = new ArrayImpl();

        //        //if ((_service.StartType == System.ServiceProcess.ServiceStartMode.Automatic) != 0)
        //        //{
        //        //    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["Адаптер"]);
        //        //}
        //        //if ((_service.ServiceType & System.ServiceProcess.ServiceType.FileSystemDriver) != 0)
        //        //{
        //        //    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["ДрайверФайловойСистемы"]);
        //        //}
        //        //if ((_service.ServiceType & System.ServiceProcess.ServiceType.InteractiveProcess) != 0)
        //        //{
        //        //    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["ИнтерактивныйПроцесс"]);
        //        //}
        //        //if ((_service.ServiceType & System.ServiceProcess.ServiceType.KernelDriver) != 0)
        //        //{
        //        //    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["ДрайверЯдра"]);
        //        //}
        //        //if ((_service.ServiceType & System.ServiceProcess.ServiceType.RecognizerDriver) != 0)
        //        //{
        //        //    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["ДрайверДляОпределенияФайловыхСистем"]);
        //        //}
        //        //if ((_service.ServiceType & System.ServiceProcess.ServiceType.Win32OwnProcess) != 0)
        //        //{
        //        //    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["ВозможенЗапускКонтроллеромДомена"]);
        //        //}
        //        //if ((_service.ServiceType & System.ServiceProcess.ServiceType.Win32ShareProcess) != 0)
        //        //{
        //        //    result.Add(GlobalsManager.GetEnum<oscript_services.ServiceTypeEnum>()["МожетИспользоватьПроцессСовместно"]);
        //        //}
        //        return result;
        //    }
        //}

        [ContextMethod("Продолжить", "Continue")]
        public void Continue()
        {
            _service.Continue();
        }

        [ContextMethod("Приостановить", "Pause")]
        public void Pause()
        {
            _service.Pause();
        }

        [ContextMethod("Запустить", "Start")]
        public void Start()
        {
            _service.Start();
        }

        [ContextMethod("ЗапуститьСПараметрами", "StartWithParams")]
        public void StartWithParams(ArrayImpl val)
        {
            int cnt = val.Count();
            string[] vals = new string[cnt];
            for (int i = 0; i < cnt; i++)
            {
                vals[i] = val.Get(i).AsString();
            }
            _service.Start(vals);
        }

        [ContextMethod("Остановить", "Stop")]
        public void Stop()
        {
            _service.Stop();
        }


    }
}
