using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace oscript_services
{
    /// <summary>
    /// Тип службы
    /// </summary>
    [SystemEnum("ТипСервиса", "ServiceType")]
    public class ServiceTypeEnum : EnumerationContext
    {
        private ServiceTypeEnum(TypeDescriptor typeRepresentation, TypeDescriptor valuesType)
            : base(typeRepresentation, valuesType)
        {

        }

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <returns></returns>
        public static ServiceTypeEnum CreateInstance()
        {
            ServiceTypeEnum instance;
            var type = TypeManager.RegisterType("ПеречислениеТипСервиса", typeof(ServiceTypeEnum));
            var enumValueType = TypeManager.RegisterType("ТипСервиса", typeof(CLREnumValueWrapper<InnerServiceType>));

            instance = new ServiceTypeEnum(type, enumValueType);

            instance.AddValue("Адаптер", "Adapter", new CLREnumValueWrapper<InnerServiceType>(instance, InnerServiceType.Adapter));
            instance.AddValue("ДрайверФайловойСистемы", "FileSystemDriver", new CLREnumValueWrapper<InnerServiceType>(instance, InnerServiceType.FileSystemDriver));
            instance.AddValue("ИнтерактивныйПроцесс", "InteractiveProcess", new CLREnumValueWrapper<InnerServiceType>(instance, InnerServiceType.InteractiveProcess));
            instance.AddValue("ДрайверЯдра", "KernelDriver", new CLREnumValueWrapper<InnerServiceType>(instance, InnerServiceType.KernelDriver));
            instance.AddValue("ДрайверДляОпределенияФайловыхСистем", "RecognizerDriver", new CLREnumValueWrapper<InnerServiceType>(instance, InnerServiceType.RecognizerDriver));
            instance.AddValue("ВозможенЗапускКонтроллеромДомена", "Win32OwnProcess", new CLREnumValueWrapper<InnerServiceType>(instance, InnerServiceType.Win32OwnProcess));
            instance.AddValue("МожетИспользоватьПроцессСовместно", "Win32ShareProcess", new CLREnumValueWrapper<InnerServiceType>(instance, InnerServiceType.Win32ShareProcess));

            return instance;
        }
    }

    /// <summary>
    /// Типы сервиса
    /// </summary>
    public enum InnerServiceType
    {
        /// <summary>
        /// Служба для аппаратного устройства, которому требуется собственный драйвер.
        /// </summary>
        Adapter,
        /// <summary>
        /// Драйвер файловой системы, который также является драйвером устройства ядра.
        /// </summary>
        FileSystemDriver,
        /// <summary>
        /// Служба, которая может взаимодействовать с рабочим столом.
        /// </summary>
        InteractiveProcess,
        /// <summary>
        /// Драйвер устройства ядра, например драйвер жесткого диска или другого аппаратного устройства нижнего уровня.
        /// </summary>
        KernelDriver,
        /// <summary>
        /// Драйвер файловой системы, используемый при запуске системы для определения файловых систем, имеющихся в системе.
        /// </summary>
        RecognizerDriver,
        /// <summary>
        /// Программа Win32, которую может запустить контроллер домена и которая подчиняется протоколу управления службами. 
        /// Этот тип службы Win32 самостоятельно выполняется в процессе.
        /// </summary>
        Win32OwnProcess,
        /// <summary>
        /// Служба Win32, которая может использовать процесс совместно с другими службами Win32.
        /// </summary>
        Win32ShareProcess
    }

}

