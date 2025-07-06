namespace _04_OopInterfaces
{
    interface IBackendDeveloper
    {
        void Develop();
    }
    interface IFrontendDeveloper
    {
        void Develop();
    }
    class FresherFullStackDeveloper:IBackendDeveloper, IFrontendDeveloper
    {
        // Common interface implementations
        public void Develop()
        {
            Console.WriteLine("Developing Frontend as well as Backend.");
        }
    }
    class ExperiencedFullStackDeveloper: IBackendDeveloper, IFrontendDeveloper
    {
        // Explicit interface implementations
        void IBackendDeveloper.Develop()
        {
            Console.WriteLine("Expert in Developing Backend.");
        }
        void IFrontendDeveloper.Develop()
        {
            Console.WriteLine("Expert in Developing Frontend.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Fresher Full Stack Developer
            FresherFullStackDeveloper dev = new FresherFullStackDeveloper();
            dev.Develop();
            IBackendDeveloper backDev = dev;
            backDev.Develop();
            IFrontendDeveloper frontDev = dev;
            frontDev.Develop();
            #endregion
            Console.WriteLine();

            #region Experienced Full Stack Developer
            ExperiencedFullStackDeveloper expDev = new ExperiencedFullStackDeveloper();
            IBackendDeveloper expBackDev = expDev;
            expBackDev.Develop();
            IFrontendDeveloper expFrontDev = expDev;
            expFrontDev.Develop();
            #endregion
        }
    }
}
