using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObjectDemo
{
    class StaticMemberDynamicWrapper : DynamicObject
    {

        private readonly TypeInfo type;

        public StaticMemberDynamicWrapper(Type type)
        {
            this.type = type.GetTypeInfo();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            //return base.TryGetMember(binder, out result);

            result = null;
            var field = FindField(binder.Name);
            if (field != null)
            {
                result = field.GetValue(null);
                return true;
            }

            var prop = FindProp(binder.Name, true);
            if (prop != null)
            {
                result = prop.GetValue(null);
                return true;
            }

            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            //return base.TrySetMember(binder, value);

            var field = FindField(binder.Name);
            if (field != null)
            {
                field.SetValue(null, value);
                return true;
            }

            var prop = FindProp(binder.Name, false);
            if (prop != null)
            {
                field.SetValue(null, value);
                return true;
            }

            return false;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            //return base.TryInvokeMember(binder, args, out result);

            result = null;

            var method = FindMethod(binder.Name, args.Select(c => c.GetType()).ToArray());
            if (method == null)
            {
                return false;
            }

            result = method.Invoke(null, args);
            return true;
        }

        private MethodInfo FindMethod(string name, Type[] paramTypes)
        {
            return type.DeclaredMethods.FirstOrDefault(m => m.Name == name && m.IsPublic && m.IsStatic && ParametersMatch(m.GetParameters(), paramTypes));
        }

        private FieldInfo FindField(string name)
        {
            return type.DeclaredFields.FirstOrDefault(f => f.Name == name && f.IsPublic && f.IsStatic);
        }

        private PropertyInfo FindProp(string name, bool get)
        {
            if (get)
            {
                return type.DeclaredProperties.FirstOrDefault(p => p.Name == name && p.GetMethod != null && p.GetMethod.IsPublic && p.GetMethod.IsStatic);
            }

            return type.DeclaredProperties.FirstOrDefault(p => p.Name == name && p.SetMethod != null && p.SetMethod.IsPublic && p.SetMethod.IsStatic);
        }

        private bool ParametersMatch(ParameterInfo[] parameterInfos, Type[] paramTypes)
        {
            if (parameterInfos.Length != paramTypes.Length)
            {
                return false;
            }

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                if (parameterInfos[i].ParameterType != paramTypes[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
