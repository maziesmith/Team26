namespace UpgradeYourself.Api.App_Start
{
    using System.Reflection;

    using Ninject;

    using UpgradeYourself.Data;
    using UpgradeYourself.Data.Contracts;

    public class DependencyInjection
    {
        public static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterMappings(kernel);

            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IUpgradeYourselfData>().To<UpgradeYourselfData>()
                .WithConstructorArgument("db", c => new UpgradeYourselfDbContext());
        }
    }
}