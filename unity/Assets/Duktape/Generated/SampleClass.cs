#if UNITY_STANDALONE_WIN
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Type: SampleClass
using System;
using System.Collections.Generic;

namespace DuktapeJS {
    using Duktape;
    [JSBindingAttribute(65537)]
    [UnityEngine.Scripting.Preserve]
    public class DuktapeJS_SampleClass : DuktapeBinding {
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int BindConstructor(IntPtr ctx)
        {
            try
            {
                var argc = DuktapeDLL.duk_get_top(ctx);
                string arg0;
                duk_get_primitive(ctx, 0, out arg0);
                string[] arg1 = new string[argc - 1];
                for (var i = 1; i < argc; i++)
                {
                    duk_get_primitive(ctx, i, out arg1[i - 1]);
                }
                var o = new SampleClass(arg0, arg1);
                DuktapeDLL.duk_push_this(ctx);
                duk_bind_native(ctx, -1, o);
                DuktapeDLL.duk_pop(ctx);
                return 0;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int Bind_SetEnum(IntPtr ctx)
        {
            try
            {
                SampleClass self;
                duk_get_this(ctx, out self);
                SampleEnum arg0;
                duk_get_enumvalue(ctx, 0, out arg0);
                var ret = self.SetEnum(arg0);
                duk_push_any(ctx, ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int Bind_CheckingVA(IntPtr ctx)
        {
            try
            {
                var argc = DuktapeDLL.duk_get_top(ctx);
                SampleClass self;
                duk_get_this(ctx, out self);
                int[] arg0 = new int[argc];
                for (var i = 0; i < argc; i++)
                {
                    duk_get_primitive(ctx, i, out arg0[i]);
                }
                var ret = self.CheckingVA(arg0);
                duk_push_any(ctx, ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int Bind_CheckingVA2(IntPtr ctx)
        {
            try
            {
                var argc = DuktapeDLL.duk_get_top(ctx);
                SampleClass self;
                duk_get_this(ctx, out self);
                int arg0;
                duk_get_primitive(ctx, 0, out arg0);
                int[] arg1 = new int[argc - 1];
                for (var i = 1; i < argc; i++)
                {
                    duk_get_primitive(ctx, i, out arg1[i - 1]);
                }
                var ret = self.CheckingVA2(arg0, arg1);
                duk_push_any(ctx, ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int Bind_Sum(IntPtr ctx)
        {
            try
            {
                SampleClass self;
                duk_get_this(ctx, out self);
                int[] arg0;
                duk_get_primitive_array(ctx, 0, out arg0);
                var ret = self.Sum(arg0);
                duk_push_any(ctx, ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int BindRead_name(IntPtr ctx)
        {
            try
            {
                SampleClass self;
                duk_get_this(ctx, out self);
                var ret = self.name;
                duk_push_any(ctx, ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int BindRead_sampleEnum(IntPtr ctx)
        {
            try
            {
                SampleClass self;
                duk_get_this(ctx, out self);
                var ret = self.sampleEnum;
                duk_push_any(ctx, (System.Int32)ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int BindRead_delegateFoo1(IntPtr ctx)
        {
            try
            {
                SampleClass self;
                duk_get_this(ctx, out self);
                var ret = self.delegateFoo1;
                duk_push_any(ctx, ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int BindWrite_delegateFoo1(IntPtr ctx)
        {
            try
            {
                SampleClass self;
                duk_get_this(ctx, out self);
                SampleClass.DelegateFoo value;
                duk_get_classvalue(ctx, 0, out value);
                self.delegateFoo1 = value;
                return 0;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int BindRead_delegateFoo2(IntPtr ctx)
        {
            try
            {
                SampleClass self;
                duk_get_this(ctx, out self);
                var ret = self.delegateFoo2;
                duk_push_any(ctx, ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int BindWrite_delegateFoo2(IntPtr ctx)
        {
            try
            {
                SampleClass self;
                duk_get_this(ctx, out self);
                SampleClass.DelegateFoo2 value;
                duk_get_classvalue(ctx, 0, out value);
                self.delegateFoo2 = value;
                return 0;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int BindRead_delegateFoo4(IntPtr ctx)
        {
            try
            {
                SampleClass self;
                duk_get_this(ctx, out self);
                var ret = self.delegateFoo4;
                duk_push_any(ctx, ret);
                return 1;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        [AOT.MonoPInvokeCallbackAttribute(typeof(DuktapeDLL.duk_c_function))]
        public static int BindWrite_delegateFoo4(IntPtr ctx)
        {
            try
            {
                SampleClass self;
                duk_get_this(ctx, out self);
                SampleClass.DelegateFoo4 value;
                duk_get_classvalue(ctx, 0, out value);
                self.delegateFoo4 = value;
                return 0;
            }
            catch (Exception exception)
            {
                return DuktapeDLL.duk_generic_error(ctx, exception.ToString());
            }
        }
        [UnityEngine.Scripting.Preserve]
        public static int reg(IntPtr ctx)
        {
            duk_begin_namespace(ctx);
            duk_begin_class(ctx, "SampleClass", typeof(SampleClass), BindConstructor);
            duk_add_method(ctx, "SetEnum", Bind_SetEnum, -1);
            duk_add_method(ctx, "CheckingVA", Bind_CheckingVA, -1);
            duk_add_method(ctx, "CheckingVA2", Bind_CheckingVA2, -1);
            duk_add_method(ctx, "Sum", Bind_Sum, -1);
            duk_add_property(ctx, "name", BindRead_name, null, -1);
            duk_add_property(ctx, "sampleEnum", BindRead_sampleEnum, null, -1);
            duk_add_field(ctx, "delegateFoo1", BindRead_delegateFoo1, BindWrite_delegateFoo1, -1);
            duk_add_field(ctx, "delegateFoo2", BindRead_delegateFoo2, BindWrite_delegateFoo2, -1);
            duk_add_field(ctx, "delegateFoo4", BindRead_delegateFoo4, BindWrite_delegateFoo4, -1);
            duk_end_class(ctx);
            duk_end_namespace(ctx);
            return 0;
        }
    }
}
#endif