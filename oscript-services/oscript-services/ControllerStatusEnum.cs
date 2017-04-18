using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace oscript_services
{
    /// <summary>
    /// Статусы службы
    /// </summary>
    [SystemEnum("Статусы", "Statuses")]
    public class ControllerStatusEnum : EnumerationContext
    {
        private ControllerStatusEnum(TypeDescriptor typeRepresentation, TypeDescriptor valuesType)
            : base(typeRepresentation, valuesType)
        {

        }

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <returns></returns>
        public static ControllerStatusEnum CreateInstance()
        {
            ControllerStatusEnum instance;
            var type = TypeManager.RegisterType("ПеречислениеСтатусы", typeof(ControllerStatusEnum));
            var enumValueType = TypeManager.RegisterType("Статусы", typeof(CLREnumValueWrapper<InnerStatus>));

            instance = new ControllerStatusEnum(type, enumValueType);

            instance.AddValue("ОжидаетВозобновления", "ContinuePending", new CLREnumValueWrapper<InnerStatus>(instance, InnerStatus.ContinuePending));
            instance.AddValue("Приостановлена", "Paused", new CLREnumValueWrapper<InnerStatus>(instance, InnerStatus.Paused));
            instance.AddValue("ПриостановкаСлужбы", "PausePending", new CLREnumValueWrapper<InnerStatus>(instance, InnerStatus.PausePending));
            instance.AddValue("Работает", "Running", new CLREnumValueWrapper<InnerStatus>(instance, InnerStatus.Running));
            instance.AddValue("ЗапускСлужбы", "StartPending", new CLREnumValueWrapper<InnerStatus>(instance, InnerStatus.StartPending));
            instance.AddValue("Остановлена", "Stopped", new CLREnumValueWrapper<InnerStatus>(instance, InnerStatus.Stopped));
            instance.AddValue("ОстановкаСлужбы", "StopPending", new CLREnumValueWrapper<InnerStatus>(instance, InnerStatus.StopPending));

            return instance;
        }
    }

    /// <summary>
    /// Статусы службы
    /// </summary>
    public enum InnerStatus
    {
        /// <summary>
        /// Ожидается возобновление работы службы. Это соответствует Win32 SERVICE_CONTINUE_PENDING Константа, которая определяется как 0x00000005.
        /// </summary>
        ContinuePending,
        /// <summary>
        /// Служба приостановлена. Это соответствует Win32 SERVICE_PAUSED Константа, которая определяется как 0x00000007.
        /// </summary>
        Paused,
        /// <summary>
        /// Идет приостановка службы. Это соответствует Win32 SERVICE_PAUSE_PENDING Константа, которая определяется как 0x00000006.
        /// </summary>
        PausePending,
        /// <summary>
        /// Служба запущена. Это соответствует Win32 SERVICE_RUNNING Константа, которая определяется как 0x00000004.
        /// </summary>
        Running,
        /// <summary>
        /// Запуск службы. Это соответствует Win32 SERVICE_START_PENDING Константа, которая определяется как 0x00000002.
        /// </summary>
        StartPending,
        /// <summary>
        /// Служба не запущена. Это соответствует Win32 SERVICE_STOPPED Константа, которая определяется как 0x00000001.
        /// </summary>
        Stopped,
        /// <summary>
        /// Остановка службы. Это соответствует Win32 SERVICE_STOP_PENDING Константа, которая определяется как 0x00000003.
        /// </summary>
        StopPending
    }

}

