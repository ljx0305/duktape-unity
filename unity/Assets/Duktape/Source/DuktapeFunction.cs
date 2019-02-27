using System;
using UnityEngine;

namespace Duktape
{
    public class DuktapeFunction : DuktapeValue
    {
        private DuktapeValue[] _argv;

        public DuktapeFunction(IntPtr ctx, uint refid)
        : base(ctx, refid)
        {
        }

        public DuktapeFunction(IntPtr ctx, uint refid, DuktapeValue[] argv)
        : base(ctx, refid)
        {
            _argv = argv;
        }

        // push 当前函数的 prototype 
        public void PushPrototype(IntPtr ctx)
        {
            this.Push(ctx);
            DuktapeDLL.duk_get_prop_string(ctx, -1, "prototype");
            DuktapeDLL.duk_remove(ctx, -2);
        }

        private void _InnerCall(IntPtr ctx, int nargs)
        {
            if (_argv != null)
            {
                nargs = _argv.Length;
                for (var i = 0; i < nargs; i++)
                {
                    _argv[i].Push(ctx);
                }
            }
            var ret = DuktapeDLL.duk_pcall(ctx, nargs);
            if (ret != DuktapeDLL.DUK_EXEC_SUCCESS)
            {
                var err = DuktapeAux.duk_to_string(ctx, -1);
                DuktapeDLL.duk_pop(ctx);
                throw new Exception(err);
            }
            DuktapeDLL.duk_pop(ctx);
        }

        // 传参调用, 如果此函数已携带js参数, js参数排在invoke参数后
        public void Invoke(object arg0)
        {
            var ctx = _ctx.rawValue;
            this.Push(ctx);
            DuktapeBinding.duk_push_var(ctx, arg0);
            _InnerCall(ctx, 1);
        }

        public void Invoke(object arg0, object arg1)
        {
            var ctx = _ctx.rawValue;
            this.Push(ctx);
            DuktapeBinding.duk_push_var(ctx, arg0);
            DuktapeBinding.duk_push_var(ctx, arg1);
            _InnerCall(ctx, 2);
        }

        public void Invoke(object arg0, object arg1, object arg2)
        {
            var ctx = _ctx.rawValue;
            this.Push(ctx);
            DuktapeBinding.duk_push_var(ctx, arg0);
            DuktapeBinding.duk_push_var(ctx, arg1);
            DuktapeBinding.duk_push_var(ctx, arg2);
            _InnerCall(ctx, 3);
        }

        public void Invoke(object arg0, object arg1, object arg2, params object[] args)
        {
            var ctx = _ctx.rawValue;
            this.Push(ctx);
            DuktapeBinding.duk_push_var(ctx, arg0);
            DuktapeBinding.duk_push_var(ctx, arg1);
            DuktapeBinding.duk_push_var(ctx, arg2);
            var size = args.Length;
            for (var i = 0; i < size; i++)
            {
                DuktapeBinding.duk_push_var(ctx, args[i]);
            }
            _InnerCall(ctx, size + 3);
        }

        public void Call()
        {
            var ctx = _ctx.rawValue;
            this.Push(ctx);
            _InnerCall(ctx, 0);
        }
    }
}
