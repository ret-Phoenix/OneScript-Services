using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace oscript_services
{
    [SystemEnum("РежимЗапуска", "StartMode")]
    class ServiceStartModeEnum : EnumerationContext
    {
        private ServiceStartModeEnum(TypeDescriptor typeRepresentation, TypeDescriptor valuesType)
            : base(typeRepresentation, valuesType)
        {

        }

        public static ServiceStartModeEnum CreateInstance()
        {
            ServiceStartModeEnum instance;
            var type = TypeManager.RegisterType("ПеречислениеРежимЗапуска", typeof(ServiceStartModeEnum));
            var enumValueType = TypeManager.RegisterType("РежимЗапуска", typeof(CLREnumValueWrapper<InnerStartMode>));

            instance = new ServiceStartModeEnum(type, enumValueType);

            instance.AddValue("Авто", "Automatic", new CLREnumValueWrapper<InnerStartMode>(instance, InnerStartMode.Automatic));
            instance.AddValue("Boot", "Boot", new CLREnumValueWrapper<InnerStartMode>(instance, InnerStartMode.Boot));
            instance.AddValue("Отключена", "Disabled", new CLREnumValueWrapper<InnerStartMode>(instance, InnerStartMode.Disabled));
            instance.AddValue("Вручную", "Manual", new CLREnumValueWrapper<InnerStartMode>(instance, InnerStartMode.Manual));
            instance.AddValue("System", "System", new CLREnumValueWrapper<InnerStartMode>(instance, InnerStartMode.System));

            return instance;
        }
    }

    public enum InnerStartMode
    {
        Automatic,
        Boot,
        Disabled,
        Manual,
        System
    }

}

