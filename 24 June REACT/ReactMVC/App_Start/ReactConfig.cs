using JavaScriptEngineSwitcher.V8;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ReactMVC.ReactConfig), "Configure")]

namespace ReactMVC
{
    public static class ReactConfig
    {
        public static void Configure()
        {
            JavaScriptEngineSwitcher.Core.JsEngineSwitcher.Current.DefaultEngineName = V8JsEngine.EngineName;
            JavaScriptEngineSwitcher.Core.JsEngineSwitcher.Current.EngineFactories.AddV8();
        }
    }
}