namespace CryptoApi.Shared.Services.Base
{
    public abstract class ServiceBase<T> where T : class, new()
    {
        private static T? derivedObject;
        private static readonly object lockObject = new object();

        public static T DerivedObject
        {
            get
            {
                if (derivedObject == null)
                {
                    lock (lockObject)
                    {
                        derivedObject ??= Activator.CreateInstance<T>();
                    }
                }

                return derivedObject;
            }
        }
    }
}
